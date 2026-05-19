using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeArea : MonoBehaviour
{
    public GameObject EscapeZone;
    [SerializeField] private float EscapeTimer;
    [SerializeField] private float EscapeTime = 1;
    [SerializeField] private bool EscapeTimerActive;

    private void Start()
    {
        EscapeTimer = 0;
        EscapeTimerActive = false;
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        Debug.Log("Opening Window...");
        EscapeTimerActive = true;
    }
    private void OnTriggerStay2D(Collider2D Player)
    {
        if (EscapeTimerActive == true)
        {
            EscapeTimer += Time.deltaTime;
            if (EscapeTimer > EscapeTime)
            {
                EscapeTimerActive = false;
                EscapeTimer = 0f;
                //Load Win Screen
                SceneManager.LoadScene(1);
            }
        }
    }
}
