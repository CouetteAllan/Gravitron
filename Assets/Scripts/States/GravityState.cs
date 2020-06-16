using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityState : JeanBaseState
{

    public override void EnterState(JeanMichelTesteur jean)
    {
        jean.isFalling = true;

        if (UIManager.Instance.SendEnergy() <= 0)
        {
            jean.triedWithoutEnergy = true;
            jean.GetComponent<Animator>().SetTrigger("NoBatteryLeft");
            return;
        }

        jean.GetComponent<Animator>().SetBool("Walking", false);
        jean.GetComponent<Animator>().SetBool("Idling", false);
        jean.GetComponent<Animator>().SetBool("Falling", true);
        jean.GetComponent<Animator>().SetBool("Jumping", false);
        jean.FXAnim.SetTrigger("GravityChange");
        jean.GetComponent<Animator>().SetTrigger("GravityChange");

    }

    public override void OnTriggerEnter2D(JeanMichelTesteur jean)
    {
        jean.TransitionToState(jean.idleState);
    }

    public override void Update(JeanMichelTesteur jean)
    {

    }

    public override void FixedUpdate(JeanMichelTesteur jean)
    {
        
    }
}
