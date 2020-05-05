using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : JeanBaseState
{
    public override void EnterState(JeanMichelTesteur jean)
    {

    }

    public override void OnCollisionEnter2D(JeanMichelTesteur jean)
    {
        jean.TransitionToState(jean.walkingState);
    }

    public override void OnCollisionStay2D(JeanMichelTesteur jean)
    {
        
    }

    public override void Update(JeanMichelTesteur jean)
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 position = jean.Rigidbody2D.position;
        position += move * jean.Speed * Time.deltaTime;
        jean.Rigidbody2D.position = position;
    }
}
