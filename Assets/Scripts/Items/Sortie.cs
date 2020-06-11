using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sortie : MonoBehaviour
{

    [SerializeField] private int levelIndex = 0;
    private float winLateTimer = 6.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur player = collision.GetComponent <JeanMichelTesteur>();
        if (player != null)
        {
            Time.timeScale = 0;
            AudioManager.Instance.Play("Victory");
            if (levelIndex == LevelList.lastLevelUnlock)
            {
                LevelList.lastLevelUnlock++;
            }
            GameManager.Instance.LateVictory(winLateTimer);
        }
        
    }


}
