using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class DetectionCircles : MonoBehaviour
{
    public Vector2 lookDir = Vector2.down; //lookDir is the direction the raycast will face when spawned, that being down
    public float FOVAngle = 75f; //Size of the angle the Raycast can cover
    public float FOVRange = 5; // Range of the angle the Raycast can cover
    public Transform rayPoint; // The GameObject the Raycast originates from

    //public LineRenderer GuardFOV;//

    [SerializeField] Transform target; //"target" is the GameObject that will be detected by the raycast

    //[SerializeField] GameManager gameManager;//

    private void Awake()
    {
        //On Awake...
        //target tracks the Player with the Raycast by sensing what GameObject has the "PlayerMovement" Script
        //Raypoint applies itself to the Guard the script is under, applying the origin of the Raycast to that specific guard
        target = GameObject.FindFirstObjectByType<PlayerMovement>()
            .gameObject.transform.GetChild(0);
        rayPoint = this.gameObject.transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        //Target direction is calculated by the position of the Player minus the coordinates of the origin of the Raycast
        //Angle Direction is created using both lookDir to spawn the Raycast in a certain direction,
        //and the targetDir to always point towards the player if lookDir is facing them 
        Vector2 targetDir = target.position - rayPoint.position;
        float angleDirection = Vector2.Angle(targetDir, lookDir);
       
        //The Raycast itself
        //It is individualized for each guard by its rayPoint (origin),
        //targetDir (always point to player IF in angle and range),
        //and FOVRange (range that the raycast can detect the player)
        RaycastHit2D detect = Physics2D.Raycast(rayPoint.position, targetDir, FOVRange);

        //If the Raycast is active...
        if (angleDirection < FOVAngle / 2 && detect.collider != null)
        {
            //If the "Player" tag is detected in the raycast...
            if (detect.collider.tag != "Player")
            {
                //Draw a Green Raycast towards the Player
                Debug.DrawRay(rayPoint.position, targetDir, Color.green);
                //GuardFOV.SetPosition(1, targetDir);
                //GuardFOV.startColor = Color.green;
                //GuardFOV.endColor = Color.green;
            }
            //If the "Player" tag is detected BUT is not in range or obstructed by obstacles...
            else
            {
                //Draw a Red Raycast towards the Player
                Debug.DrawRay(rayPoint.position, targetDir, Color.red);
                //GuardFOV.SetPosition(1, transform.position + rayPoint.position * FOVRange);
                //GuardFOV.startColor = Color.red;
                //GuardFOV.endColor = Color.red;
            }
        }
    }


}
