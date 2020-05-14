using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : JeanBaseState
{
    public override void EnterState(JeanMichelTesteur jean)
    {
        jean.GetComponent<Animator>().SetBool("Walking", false);
        jean.GetComponent<Animator>().SetBool("Idling", false);
        jean.GetComponent<Animator>().SetBool("Falling", false);
        jean.GetComponent<Animator>().SetBool("Jumping", true);
    }

    public override void OnCollisionEnter2D(JeanMichelTesteur jean)
    {
        jean.TransitionToState(jean.idleState);
    }


    public override void Update(JeanMichelTesteur jean)
    {
        Vector2 position = jean.Rigidbody2D.position;
        position += jean.Move * jean.Speed * Time.deltaTime;
        jean.Rigidbody2D.position = position;
    }
}
