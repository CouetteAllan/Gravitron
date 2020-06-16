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

        if (jean.TutoPresent)
        {
            jean.tutoEnergyScene2.SetActive(false); //enlève le filtre noir du niveau 2 lorsque l'on bouge
        }
    }

    public override void FixedUpdate(JeanMichelTesteur jean)
    {
        Vector2 position = jean.Rigidbody2D.position;
        position += jean.Speed * jean.Move * Time.deltaTime;
        jean.Rigidbody2D.position = position;
    }

    public override void OnTriggerEnter2D(JeanMichelTesteur jean)
    {
        jean.TransitionToState(jean.idleState);
    }


    public override void Update(JeanMichelTesteur jean)
    {

    }
}
