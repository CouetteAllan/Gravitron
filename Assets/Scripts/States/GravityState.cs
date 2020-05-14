using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityState : JeanBaseState
{
    public override void EnterState(JeanMichelTesteur jean)
    {
        if (UIManager.Instance.SendEnergy() == 0)
        {
            jean.TransitionToState(jean.idleState);
        }

        jean.GetComponent<Animator>().SetBool("Walking", false);
        jean.GetComponent<Animator>().SetBool("Idling", false);
        jean.GetComponent<Animator>().SetBool("Falling", true);
        jean.GetComponent<Animator>().SetBool("Jumping", false);
        jean.ZwoshAnim.SetTrigger("GravityChange");

        float gravityValueX = Physics2D.gravity.x;
        float gravityValueY = Physics2D.gravity.y;

        jean.GetComponent<Animator>().SetFloat("GravityDirectionX", gravityValueX);
        jean.GetComponent<Animator>().SetFloat("GravityDirectionY", gravityValueY);
        
    }

    public override void OnCollisionEnter2D(JeanMichelTesteur jean)
    {
        jean.TransitionToState(jean.idleState);
        
    }

    public override void Update(JeanMichelTesteur jean)
    {
    }
}
