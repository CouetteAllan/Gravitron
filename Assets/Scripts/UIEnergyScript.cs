using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnergyScript : MonoBehaviour
{
    [SerializeField] private Image energyBar;
    [SerializeField] private Text energyTxt;
    private int energy = 0;

    private void Start()
    {
        ChangeEnergy(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeEnergy(-1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeEnergy(1);
        }
    }

    public void ChangeEnergy(int amount)
    {
        energy += amount;
        if (energy < 0)
        {
            energy = 0;
        }
        energyTxt.text = " X" + energy;
    }
}
