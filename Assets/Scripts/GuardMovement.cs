using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class GuardMovement : MonoBehaviour
{
    public float guardspeed;
    public Transform[] patrolPoints;
    public float idleTime;
    int currentPointIndex;

    bool once;
    private void Update()
    {
        //Unalerted Guard Pathfinding
        if (transform.position != patrolPoints[currentPointIndex].position)
        {
            transform.position = Vector2.MoveTowards
                (transform.position, patrolPoints[currentPointIndex].position, guardspeed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }
    }

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
