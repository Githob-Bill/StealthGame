using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Detection_Meter : MonoBehaviour
{
    public static Detection_Meter instance;
    public Image fill;
    public int Detected = 2;
    
    private void Awake()
    {
        instance = this;
    }

    public void DetectionRate(int Detection, int Detected)
    {
        fill.fillAmount = Detection;

        if (Detection >= Detected)
        {
            //Load Lose Screen
            SceneManager.LoadScene(2);
        }

    }
}
