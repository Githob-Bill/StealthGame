using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;

    public float panspeed = 0.1f;
    private Vector3 mousepos;
    private Camera mainCamera;
 
    void Update()
    {

        //Panning Camera (WIP)
        if (Input.GetMouseButton(2))
        {
            Vector3 mousepos = Input.mousePosition;

            Vector3 campos = new Vector3
                (mousepos.x * panspeed * Time.deltaTime, mousepos.y * panspeed * Time.deltaTime, 0);
            // * panspeed

            transform.Translate(campos, Space.World);
        }
        
        //Reset Panning Camera (WIP)
        if (Input.GetMouseButtonUp(2))
        {
            transform.Translate(Vector3.zero, Space.Self);
        }

    }
}
