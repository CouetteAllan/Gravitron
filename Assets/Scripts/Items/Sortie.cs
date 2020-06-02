using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sortie : MonoBehaviour
{

    [SerializeField] private int levelIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur player = collision.GetComponent <JeanMichelTesteur>();
        if (player != null)
        {
            if (levelIndex == LevelList.lastLevelUnlock)
            {
                LevelList.lastLevelUnlock++;
            }
            GameManager.Instance.ChangeState(GameManager.GameState.Victory);
        }
        
    }
}
