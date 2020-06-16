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
            player.won = true;
            AudioManager.Instance.Play("Victory");
            AudioManager.Instance.Stop("Theme");
            if (levelIndex == LevelList.lastLevelUnlock)
            {
                LevelList.lastLevelUnlock++;
            }
            GameManager.Instance.LateVictory(winLateTimer);
        }
        
    }


    public int GetIndex()
    {
        return levelIndex;
    }

}
