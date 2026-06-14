using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffectManager : MonoBehaviour
{
    public Collider2D[] LootColliders;

    public static SoundEffectManager Soundinstance;
    private AudioSource audioSource;
    public AudioClip Glasscut;

    public int InRangeStatus = 0;

    private void Start()
    {
        Soundinstance = this;
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerStay2D(Collider2D Player)
    {
        InRangeStatus = 1;
    }
    private void OnTriggerExit2D(Collider2D Player)
    {
        InRangeStatus = 2;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRangeStatus == 1)
        {
            audioSource.clip = Glasscut;
            PlaySound();
        }
        else if (Input.GetKeyUp(KeyCode.E) || InRangeStatus == 2)
        {
            StopSound();
        }
    }
    public void PlaySound()
    {
        audioSource.Play();
        Debug.Log("Cutting Glass..");
    }
    public void StopSound()
    {
        if (audioSource.clip)
        {
            audioSource.Stop();
            Debug.Log("Canceled");
            InRangeStatus = 0;
        }
        if (!audioSource.clip)
        {
            return;
        }
    }
}
