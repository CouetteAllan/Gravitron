using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnergyScript : MonoBehaviour
{
    [SerializeField] private Image energyBar;
    [SerializeField] private List<Image> listEnergy = new List<Image> { };
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
        energy = Mathf.Clamp(energy, 0, listEnergy.Count);
        for (int i = 0; i < listEnergy.Count; i++)
        {
            if (i < energy)
            {
                listEnergy[i].enabled = true;
            }
            else
            {
                listEnergy[i].enabled = false; ;
            }
        }
    }
}
