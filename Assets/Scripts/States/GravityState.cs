using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityState : JeanBaseState
{
    private float rotationSpeed = 5;

    public override void EnterState(JeanMichelTesteur jean)
    {
        if (UIManager.Instance.SendEnergy() <= 1)
        {
            jean.TransitionToState(jean.idleState);

            return;
        }
        if (UIManager.Instance.SendEnergy() == 0)
        {
            jean.TransitionToState(jean.idleState);
        }

        jean.GetComponent<Animator>().SetBool("Walking", false);
        jean.GetComponent<Animator>().SetBool("Idling", false);
        jean.GetComponent<Animator>().SetBool("Falling", true);
        jean.GetComponent<Animator>().SetBool("Jumping", false);
        jean.ZwoshAnim.SetTrigger("GravityChange");
        jean.GetComponent<Animator>().SetTrigger("GravityChange");

    }

    public override void OnTriggerEnter2D(JeanMichelTesteur jean)
    {
        jean.TransitionToState(jean.idleState);
        
    }

    public override void Update(JeanMichelTesteur jean)
    {

    }
}
