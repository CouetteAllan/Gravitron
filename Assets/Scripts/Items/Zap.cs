using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : InteractableObjects
{
    [SerializeField]
    private CamShake shake;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.shake.Shake();
        JeanMichelTesteur jean = collision.GetComponent <JeanMichelTesteur>();
        if (jean != null)
        {            
            jean.Dead(0.2f);
        }
    }
}
