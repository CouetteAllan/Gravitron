using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : JeanBaseState
{
    private Vector2 jumpDirection;
    public override void EnterState(JeanMichelTesteur jean)
    {
        Debug.Log("JE NE BOUGE PAS");
    }

    public override void OnCollisionEnter2D(JeanMichelTesteur jean)
    {
        
    }

    public override void OnCollisionStay2D(JeanMichelTesteur jean)
    {
        
    }

    public override void Update(JeanMichelTesteur jean)
    {
        if (Input.GetButton("Horizontal"))
        {
            jean.TransitionToState(jean.walkingState);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpDirection = -GameManager.Instance.SendGravityDirection();

            jean.Rigidbody2D.AddForce(jumpDirection * jean.Jump);
            jean.TransitionToState(jean.jumpingState);
        }
        Debug.Log("JE NE BOUGE PAS");

    }
}
