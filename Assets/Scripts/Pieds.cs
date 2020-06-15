using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieds : MonoBehaviour
{
    private bool groundCheck;
    private void Start()
    {
        this.groundCheck = GetComponentInParent<JeanMichelTesteur>().isGrounded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        groundCheck = true;
        GetComponentInParent<JeanMichelTesteur>().currentState.OnTriggerEnter2D(GetComponentInParent<JeanMichelTesteur>());
        GetComponentInParent<JeanMichelTesteur>().isGrounded = groundCheck;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        groundCheck = false;
        GetComponentInParent<JeanMichelTesteur>().isGrounded = groundCheck;
    }
}
