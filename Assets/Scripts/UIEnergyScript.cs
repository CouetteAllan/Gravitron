using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnergyScript : MonoBehaviour
{
    public static UIEnergyScript Instance { get; private set; } 
    [SerializeField] private Image energyBar;
    [SerializeField] private Text energyTxt;
    private int energy = 0;
    private int half = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeEnergy(0);
    }

    public void ChangeEnergy(int amount, bool semi = false)
    {
        if (semi)
        {
            half++;
            if (half >= 2)
            {
                half -= 2;
                energy++;
            }
        }
        else
        {
            energy += amount;
            if (energy < 0)
            {
                energy = 0;
            }
        }
        energyTxt.text = " X" + energy;
    }
}
