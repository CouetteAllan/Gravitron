﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Le GameManager est null lulz");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }


    public void ChangeGravity(float x, float y)
    {

    }
}
