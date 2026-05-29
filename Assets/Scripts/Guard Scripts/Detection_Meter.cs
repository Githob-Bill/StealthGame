using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Detection_Meter : MonoBehaviour
{
    public static Detection_Meter instance;
    public Image fill;
    public float Detection;

    public bool startDetecting = false;
    public bool SearchMode;

    public Slider DetectionMeter;
    private void Start()
    {
        instance = this;
        fill.fillAmount = Detection;
    }

    public void DetectionRate()
    {
        Detection += Time.deltaTime * 2;
        DetectionMeter.value = Detection;

        if (Detection >= 1)
        {
            Detection = 1;
            //Load Lose Screen
            SceneManager.LoadScene(2);
        }
        if (Detection >= 0.5)
        {
            Suspicous();
        }
    }

    public void LowerDetectionRate()
    {
        Detection -= Time.deltaTime;
        DetectionMeter.value = Detection;

        if (Detection <= 0)
        {
            Detection = 0;
        }
    }

    public void Suspicous()
    {
        if (Detection >= 0.5)
        {
            StartCoroutine(GuardSuspicion());
        }
    }

    //Search Mode(WIP)
    public IEnumerator GuardSuspicion()
    {
        //Play a "?" image on top of the guard
        yield return new WaitForSeconds(1f);

        SearchMode = true;
        if (SearchMode)
        {
            GuardMovement.moveInstance.SearchMode();
        }
        

    }
}
