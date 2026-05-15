using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    private SpriteRenderer Crosshair;
    private Vector3 mousePos;
    private float mouseSpeed = 0.1f;
    private void Start()
    {
       Crosshair = GetComponent<SpriteRenderer>();
       Crosshair.enabled = false;
    }

    private void Update()
    {
        //Crosshair (WIP)  
        if (Input.GetMouseButton(1))
        {
            Crosshair.enabled = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePos, mouseSpeed);
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            Crosshair.enabled = false;
        }
    }

}


