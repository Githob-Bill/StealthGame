using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movespeed;
    private Vector3 mousepos;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        //Shiftwalk/Sneak
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movespeed = 2f;
        }
        else
        {
            movespeed = 5f;
        }

        //Basic Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * movespeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * movespeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * movespeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * movespeed * Time.deltaTime, Space.World);
        }
    }
}
