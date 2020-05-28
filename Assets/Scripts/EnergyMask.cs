﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMask : MonoBehaviour
{
    private static EnergyMask instance;
    public static EnergyMask Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("energyMask null");
            }
            return instance;
        }
    }

    [SerializeField] private Image mask;
    private float originalWidth;

    private void Awake()
    {
        instance = this;
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
