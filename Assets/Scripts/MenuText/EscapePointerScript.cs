using CodeMonkey.Utils;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EscapePointerScript : MonoBehaviour
{
    [SerializeField] private Camera UICamera;
    public GameObject Pointer;

    private Vector3 targetPosition;
    [SerializeField] private RectTransform pointerRectTransform;

    public static EscapePointerScript pointerInstance;
    private void Awake()
    {
        Pointer.GetComponent<SpriteRenderer>().enabled = false;

        targetPosition = new Vector3(0, -4);
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 Direction = (toPosition - fromPosition).normalized;
        float angle = UtilsClass.GetAngleFromVector(Direction);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        Vector3 targetPosScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
    }
}
