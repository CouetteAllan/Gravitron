using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : JeanBaseState
{
    public override void EnterState(JeanMichelTesteur jean)
    {

    }

    public override void OnCollisionEnter2D(JeanMichelTesteur jean)
    {
        
    }

    public override void Update(JeanMichelTesteur jean)
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 position = jean.Rigidbody2D.position;
        position += move * jean.Speed * Time.deltaTime;
        jean.Rigidbody2D.position = position;

        if (Input.GetButtonUp("Right")&&Input.GetButtonUp("Left"))
        {
            jean.TransitionToState(jean.idleState);
        }
        if (Input.GetButtonDown("Jump"))
        {
            jean.Rigidbody2D.AddForce(Vector2.up * jean.Jump);
            jean.TransitionToState(jean.jumpingState);
        }
    }
}
