using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    [SerializeField] GameObject Crosshair;
    private Vector3 mousePos;
    private float mouseSpeed = 0.1f;
    private void Start()
    {
        Crosshair.SetActive(false);
    }

    private void Update()
    {
        //Crosshair (WIP)  
        if (Input.GetMouseButton(1))
        {
            Crosshair.SetActive(true);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePos, mouseSpeed);
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            Crosshair.SetActive(false);
        }
    }

}


