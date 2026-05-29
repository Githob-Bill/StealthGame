using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TakeCountScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI takeCount;
    private LootScript Loot;
    public int totalCash = 0;
    public static TakeCountScript instance;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {  
        takeCount.text = "Payout: $" + totalCash.ToString();
    }

    public void CollectCash(int Cash)
    {
        totalCash += Cash;
        takeCount.text = "Payout: $" + totalCash.ToString();
    }
}