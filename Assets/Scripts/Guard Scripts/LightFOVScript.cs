using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class LightFOVScript : MonoBehaviour
{
    public Light2D GuardLightFOV;

    public GuardMovement GuardMovement;
    public GuardMovement GuardVelocity;

    [SerializeField] private DetectionCircles fov;

    public Vector2 velocity;
    public float guardspeed;
    public float rotationSpeed = 5;

    private void Awake()
    {
        guardspeed = GuardMovement.guardspeed;
        velocity = GuardMovement.velocity;
        fov = GetComponent<DetectionCircles>();
    }

    void Update()
    {
        velocity = GuardMovement.velocity;
        Vector2 movement = velocity.normalized;
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
            float currentAngle = transform.rotation.eulerAngles.z;
            float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }
}
