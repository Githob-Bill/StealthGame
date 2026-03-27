using Unity.Hierarchy;
using UnityEngine;

public class DetectionCircles : MonoBehaviour
{

    public float rotationSpeed;
    public float visionDistance;
  

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, visionDistance);
        if (hitInfo.collider != null)
        {
            Debug.DrawRay(transform.position, transform.position + transform.right * visionDistance, Color.red);

            if (hitInfo.collider.tag != "Player")
            {
                Debug.Log("Player Seen");
                Debug.DrawRay(transform.position, transform.position + transform.right * visionDistance, Color.green);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, hitInfo.point, Color.red);
        }
    }
}
