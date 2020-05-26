using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : InteractableObjects
{



    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        JeanMichelTesteur jean = collision.GetComponent <JeanMichelTesteur>();
        if (jean != null)
        {            
            jean.Dead(0.2f);
        }
    }
}
