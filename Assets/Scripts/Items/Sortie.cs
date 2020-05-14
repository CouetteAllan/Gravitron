using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sortie : MonoBehaviour
{
    [SerializeField]
    private Timer t;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur player = collision.GetComponent <JeanMichelTesteur>();
        if (player != null)
        {
            t.Finish();
            GameManager.Instance.ChangeState(GameManager.GameState.Victory);
        }
        
    }
}
