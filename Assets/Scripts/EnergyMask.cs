using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMask : MonoBehaviour // Emile
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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
    }

    public void ChangeMaskSize(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 720 * value);
    }
}
