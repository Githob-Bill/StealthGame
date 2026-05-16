using TMPro;
using UnityEngine;

public class QuotaCountScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quotaText;
    
    public int totalCash = 0;
    public int QuotaCountMax = 80000;
    public static QuotaCountScript quotaInstance;

    public GameObject EscapeZone;

    private void Awake()
    {
        quotaInstance = this;
        quotaText.text = "Quota Needed: $80000";
    }

    public void QuotaCheck(int Cash)
    {
        totalCash += Cash;
        if (totalCash >= QuotaCountMax)
        {
            EscapeZone.SetActive(true);
            quotaText.text = "Escape now or Loot more!";
        }
    }
}
