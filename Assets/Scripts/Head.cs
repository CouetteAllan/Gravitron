using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    //------------------------- Allan ----------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cube cube = collision.gameObject.GetComponent<Cube>();
        if(cube != null)
        {
            GetComponentInParent<JeanMichelTesteur>().isStomped = true; //met la variable d'écrasement à true pour jean-mi
        }
    }
}
