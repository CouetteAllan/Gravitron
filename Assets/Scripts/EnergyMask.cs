using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMask : MonoBehaviour
{
    public static EnergyMask Instance { get; private set; }

    [SerializeField] private Image mask;
    private float originalWidth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        originalWidth = this.mask.rectTransform.rect.width;
    }

    public void ChangeMaskSize(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalWidth * value);
    }
}
