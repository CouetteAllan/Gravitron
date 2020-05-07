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
        
    }

    public override void OnCollisionStay2D(JeanMichelTesteur jean)
    {
        Debug.Log("coucou");
        jean.TransitionToState(jean.idleState);
    }

    public override void Update(JeanMichelTesteur jean)
    {
        
    }
}
