using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class LightFOVScript : MonoBehaviour
{
    Light2D GuardLightFOV;
    Vector2 LightDirection;

    [SerializeField] DetectionCircles fov;
    [SerializeField] Vector3 velocity, prevPos;

    public void Update()
    {
        velocity = (transform.position - prevPos) / Time.deltaTime;
        prevPos = transform.position;
        LightDirection = velocity.normalized;

        if (LightDirection.x > 0)
        {
            transform.Rotate(0, 0, 180);
            fov.lookDir = Vector2.right;
        }
        else if (LightDirection.x < 0)
        {
            transform.Rotate(0, 0, 0);
            fov.lookDir = Vector2.left; 
        }

        if (LightDirection.y > 0)
        {
            transform.Rotate(0, 0, -90);
            fov.lookDir = Vector2.up;
        }
        else if (LightDirection.y < 0)
        {
            transform.Rotate(0, 0, 90);
            fov.lookDir = Vector2.down;
        }
    }
}
