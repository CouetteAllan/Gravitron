using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sortie : MonoBehaviour
{
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur player = collision.GetComponent <JeanMichelTesteur>();
        if (player != null)
        {
            LevelList.lastLevelUnlock++;
            GameManager.Instance.ChangeState(GameManager.GameState.Victory);
        }
        
    }
}
