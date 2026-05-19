using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class GuardMovement : MonoBehaviour
{
    //Guard Movement Vars
    public float guardspeed;
    public Transform[] patrolPoints;
    public float idleTime;
    public int currentPointIndex;
    bool once;
    
    //Guard FOV Vars
    [SerializeField] DetectionCircles fov;

    //Guard Rotation Vars
    [SerializeField] public Vector3 velocity, prevPos;
    public Vector2 Direction;
    
    Animator anim;
    
    //Guard FOV link w/ movement
    private void Awake()
    {
        fov = GetComponent<DetectionCircles>();
    }

    private void Update()
    {
        //Unalerted Guard Pathfinding
        if (transform.position != patrolPoints[currentPointIndex].position)
        {
            transform.position = Vector2.MoveTowards
                (transform.position, patrolPoints[currentPointIndex].position, guardspeed * Time.deltaTime);
            //idle = false;
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
            //idle = true;
        }

        //Velocity to control direction of FOV
        velocity = (transform.position - prevPos) / Time.deltaTime;
        prevPos = transform.position;
        Direction = velocity.normalized;

        if (Direction.x > 0) fov.lookDir = Vector2.right;
        else if (Direction.x < 0) fov.lookDir = Vector2.left;

        if (Direction.y > 0) fov.lookDir = Vector2.up;
        else if (Direction.y < 0) fov.lookDir = Vector2.down;

        //Animations (WIP)
        //if (Direction.x == 1 || Direction.x == -1 || Direction.y == 1 || Direction.y == -1)
        {
            //anim.SetFloat("Horizontal", Direction.x);
            //anim.SetFloat("Vertical", Direction.y);
        }
        //anim.SetBool("Idle", idle);
    }

    //Idle Time after reaching each point
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(idleTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }
}
