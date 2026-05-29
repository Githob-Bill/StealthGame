using TMPro;
using UnityEngine;

public class InteractionText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactText;

    public static InteractionText interactInstance;

    private void Awake()
    {
        interactInstance = this;
        interactText.text = "Press [E] to Loot";
        interactText.gameObject.SetActive(false);
    }

    public void InteractionRangeCheck()
    {
        interactText.text = "Press [E] to Loot";
        interactText.gameObject.SetActive(true);
    }

    public void InteractionRangeCheckLooting()
    {
        interactText.text = "Looting...";
    }

    public void InteractionRangeCheckFail()
    {
        interactText.gameObject.SetActive(false);
    }
}
