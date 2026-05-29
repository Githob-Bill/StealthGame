using System.Collections;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class DetectionCircles : MonoBehaviour
{
    public Vector2 lookDir = Vector2.down;
    public float FOVAngle = 75f;
    public float FOVRange = 5;
    public Transform rayPoint;

    [SerializeField] Transform target;

    public GuardMovement GuardMovement;
    public GuardMovement GuardVelocity;

    [SerializeField] private DetectionCircles fov;
    public Vector2 velocity;
    public float guardspeed;
    public float rotationSpeed = 35;

    public bool Detecting;


    private void Awake()
    {
        target = GameObject.FindFirstObjectByType<PlayerMovement>()
            .gameObject.transform.GetChild(0);
        rayPoint = this.gameObject.transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        Vector2 targetDir = target.position - rayPoint.position;
        float angleDirection = Vector2.Angle(targetDir, lookDir);

        RaycastHit2D detect = Physics2D.Raycast(rayPoint.position, targetDir, FOVRange);

        if (angleDirection < FOVAngle / 2 && detect.collider != null)
        {
            if (!detect.collider.CompareTag("Player"))
            {
                GameObject currentHit = detect.collider.gameObject;
                Debug.DrawRay(rayPoint.position, targetDir, Color.green);
                Detection_Meter.instance.LowerDetectionRate();
            }
            else
            {
                Debug.DrawRay(rayPoint.position, targetDir, Color.red);
                Detection_Meter.instance.DetectionRate();
            }
        }
    }

    private void Update()
    {
        velocity = GuardMovement.velocity;
        Vector2 movement = velocity.normalized;
    }
}
