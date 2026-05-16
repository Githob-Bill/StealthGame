using System;
using System.Collections;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime;

public class LootScript : MonoBehaviour
{

    //To-do
    //When over trigger: hold E to start an Interaction Timer that must be held (5 sec?)
    //When complete timer: Disable Loot, add to quota in Canvas.
    //When quota reached: Unlock escape trigger.
    //Fix Soon!!!!

    [SerializeField] private Collider2D InteractBox;
    private float InteractTime;
    [SerializeField] private float InteractTimer;
    [SerializeField] bool InteractTimeActive;


    public int Cash = 20000;
    private bool Looted;
    public bool InRange;
    public GameObject Loot;

    public TextMeshProUGUI InteractionText;
    //private string InteractText = "[F] to Steal";

    public void Start()
    {
        Looted = false;
        InteractTime = 3f;
        InteractTimer = 0f;
        InteractTimeActive = false;
    }

    //Keybinds for Trigger
    private void OnTriggerEnter2D(Collider2D Player)
    {
        Debug.Log("Entered Looting Range");
    }
    private void OnTriggerStay2D(Collider2D Player)
    {
        //InteractText
        InRange = true;
        if (InRange == true)
        {
            //InteractionText.text = InteractText;
            //InteractionText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Looting...");
            }
            if (Input.GetKey(KeyCode.E))
            {
                InteractTimeActive = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D Player)
    {
        Debug.Log("Out of Range!");
        //InteractionText.gameObject.SetActive(false);
        InteractTimeActive = false;
        InteractTimer = 0;
    }

    private void Update()
    {   
        //Interaction Timer
        if (InteractTimeActive == true)
        {
            InteractTimer += Time.deltaTime;
            if (InteractTimer > InteractTime)
            {
                InteractTimeActive = false;
                InteractTimer = 0f;
                
                TakeCountScript.instance.CollectCash(Cash);
                QuotaCountScript.quotaInstance.QuotaCheck(Cash);

                Loot.GetComponent<Renderer>().material.color = Color.gray;
                Looted = true;

                if (Looted == true)
                {
                    Debug.Log("Finished Looting");
                    Destroy(this);
                }
            }
        }
    }
}
