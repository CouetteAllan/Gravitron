using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnergyScript : MonoBehaviour
{
    [SerializeField] private Image energyBar;
    private List<Image> listEnergy = new List<Image> { };
    private int energy = 2;
    private Canvas parent;

    private void Start()
    {
        foreach (Image energy in listEnergy)
        {
            listEnergy.Add(energy);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            energy++;
            ChangeEnergy(energy);
        }
    }

    public void ChangeEnergy(int energy)
    {
        for (int i = 0; i < energy; i++)
        {
            listEnergy.Add(energyBar);
        }
        for (int i = listEnergy.Count - energy; i < listEnergy.Count; i++)
        {
            Image battery = Instantiate(energyBar);
            battery.transform.SetParent(transform);
            battery.rectTransform.position = new Vector2(i * 40, this.transform.position.y - 12);
        }
    }
}
