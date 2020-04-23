using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : JeanBaseState
{
    public override void EnterState(JeanMichelTesteur jean)
    {
        
    }

    public override void OnCollisionEnter2D(JeanMichelTesteur jean)
    {
        
    }

    public override void Update(JeanMichelTesteur jean)
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            jean.TransitionToState(jean.walkingState);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jean.Rigidbody2D.AddForce(Vector2.up * jean.Jump);
            jean.TransitionToState(jean.jumpingState);
        }

    }
}
