using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class EscapeArea : MonoBehaviour
{
    public GameObject EscapeZone;
    [SerializeField] private float EscapeTimer;
    [SerializeField] private float EscapeTime = 3;
    [SerializeField] private bool EscapeTimerActive;

    private AudioSource EscapeAudio;
    public AudioClip EscapeSound;

    private void Start()
    {
        EscapeTimer = 0;
        EscapeTimerActive = false;

        EscapeAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        Debug.Log("Opening Window...");
        EscapeTimerActive = true;

        EscapeAudio.clip = EscapeSound;
        EscapeAudio.Play();
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
                SceneManager.LoadScene(3);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D Player)
    {
        EscapeAudio.Stop();
    }
}
