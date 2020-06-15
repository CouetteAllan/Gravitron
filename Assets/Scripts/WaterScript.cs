using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public static WaterScript Instance { get; private set; }

    [SerializeField] private List<GameObject> waterParticles = new List<GameObject>();

    private void Awake()
    {
        Instance = Instance == null ? this : null;
    }

    private void Start()
    {
        ChangeWater(UIManager.Instance.SendEnergy());
    }

    public void ChangeWater(int currentEnergy)
    {
        Debug.Log("WaterProcessing");
        Debug.Log("currentEnergy = " + currentEnergy);

        for (int i = 0; i < waterParticles.Count; i++ )
        {
            if (5 * currentEnergy > i)
            {
                Debug.Log("2 x currentEnergy < " + i);
                Debug.Log("Water.SetActive(true)");
                waterParticles[i].SetActive(true);
            }
            else
            {
                Debug.Log("2 x currentEnergy > " + i);
                Debug.Log("water.SetActive(false)");
                waterParticles[i].SetActive(false);
            }
        }
    }
}
