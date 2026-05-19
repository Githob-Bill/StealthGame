using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class Detection_Meter : MonoBehaviour
{
    public static Detection_Meter instance;
    public Image fill;
    public float Detection;

    public bool startDetecting = false;

    public Slider DetectionMeter;
    private void Start()
    {
        instance = this;
        fill.fillAmount = Detection;
    }

    public void DetectionRate()
    {
        startDetecting = true;

        if (startDetecting == true)
        {
            Detection += Time.deltaTime;
            DetectionMeter.value = Detection;

            if (Detection >= 1)
            {
                Detection = 1;
                //Load Lose Screen
                SceneManager.LoadScene(2);
            }
        }
    }

    public void LowerDetectionRate()
    {
        startDetecting = false;

        if (startDetecting == false)
        {
            Detection -=  Time.deltaTime;
            DetectionMeter.value = Detection;

            if (Detection <= 0)
            {
                Detection = 0;
            }
        }
    }
}
