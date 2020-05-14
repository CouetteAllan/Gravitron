using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieds : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
            GetComponentInParent<JeanMichelTesteur>().currentState.OnTriggerEnter2D(GetComponentInParent<JeanMichelTesteur>());
            Debug.Log("BONJOUR");
        
    }
}
