﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelList : MonoBehaviour // Emile
{
    public static int lastLevelUnlock = 1;

    [SerializeField] private List<Level> listLevel;



    public void CheckLevelUnlock()
    {
        Debug.Log("Checking Levels, " + listLevel.Count);
        for (int i = 0; i < listLevel.Count; i++)
        {
            if (i < lastLevelUnlock)
            {
                listLevel[i].EnableButton(true);
            }
            else
            {
                listLevel[i].EnableButton(false);
            }
        }
    }
}
