using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cube cube = collision.gameObject.GetComponent<Cube>();
        if(cube != null)
        {
            GetComponentInParent<JeanMichelTesteur>().isStomped = true;
        }
    }
}
