using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : InteractableObjects
{
    [SerializeField]
    private CamShake shake;
    [SerializeField]
    private Timer t;



    protected override void ActivateObject()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    protected override void DisabledObject()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.shake.Shake();
        JeanMichelTesteur jean = collision.GetComponent <JeanMichelTesteur>();
        if (jean != null)
        {
            t.Finish();
            Destroy(jean.gameObject);
        }            
            jean.Dead();
        }
    }
