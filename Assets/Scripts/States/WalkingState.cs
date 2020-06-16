using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : JeanBaseState
{
    private Vector2 gravityDirection;
    private Vector2 jumpDirection;

    public override void EnterState(JeanMichelTesteur jean)
    {
        this.gravityDirection = GameManager.Instance.SendGravityDirection();
        jean.GetComponent<Animator>().SetBool("Walking", true);
        jean.GetComponent<Animator>().SetBool("Idling", false);
        jean.GetComponent<Animator>().SetBool("Falling", false);
        jean.GetComponent<Animator>().SetBool("Jumping", false);

        if (jean.TutoPresent)
        {
            jean.tutoEnergyScene2.SetActive(false); //enlève le filtre noir d
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
        
    }

    

    public override void Update(JeanMichelTesteur jean)
    {
        float horizontal = Input.GetAxis("Horizontal");
        jean.GetComponent<Animator>().SetFloat("Move",horizontal);

        if (Input.GetButtonUp("Horizontal"))
        {
            jean.TransitionToState(jean.idleState);
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpDirection = -gravityDirection;

            jean.Rigidbody2D.AddForce(jumpDirection * jean.Jump);
            jean.TransitionToState(jean.jumpingState);
        }
    }
}
