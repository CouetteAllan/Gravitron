﻿using System.Collections;
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

        for (int i = 0; i < waterParticles.Count; i++ )
        {
            if (5 * currentEnergy > i)
            {
                waterParticles[i].SetActive(true);
            }
            else
            {
                waterParticles[i].SetActive(false);
            }
        }
    }
}
