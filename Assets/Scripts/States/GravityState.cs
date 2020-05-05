using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityState : JeanBaseState
{
    public override void EnterState(JeanMichelTesteur jean)
    {

    }

    public override void OnCollisionEnter2D(JeanMichelTesteur jean)
    {
        jean.TransitionToState(jean.idleState);
        Debug.Log("Atterri");
    }

    public override void OnCollisionStay2D(JeanMichelTesteur jean)
    {
        jean.TransitionToState(jean.idleState);
    }

    public override void Update(JeanMichelTesteur jean)
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 position = jean.Rigidbody2D.position;
        position += move * jean.Speed * Time.deltaTime;
        jean.Rigidbody2D.position = position;

        Debug.Log("GRAVITY");
    }
}
