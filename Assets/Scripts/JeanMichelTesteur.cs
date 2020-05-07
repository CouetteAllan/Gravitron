﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanMichelTesteur : MonoBehaviour
{
    #region Variables Jean Michel
    [HideInInspector]
    public JeanBaseState currentState;
    public readonly IdleState idleState = new IdleState();
    public readonly WalkingState walkingState = new WalkingState();
    public readonly JumpingState jumpingState = new JumpingState();
    public readonly GravityState gravityState = new GravityState();

    private Vector2 move;
    public Vector2 Move
    {
        get { return move; }
    }

    [SerializeField]
    private float speed;
    public float Speed
    {
        get { return speed; }
    }
    [SerializeField]
    private float jump = 3500;
    public float Jump
    {
        get { return jump; }
    }

    private Rigidbody2D rb2d;
    public Rigidbody2D Rigidbody2D
    {
        get { return rb2d; }
    }
    #endregion 

    void Start()
    {
        TransitionToState(idleState);
        rb2d = this.GetComponent<Rigidbody2D>();
    }
    
    
    void Update()
    {
        MoveWithGravity();


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(GameManager.Instance.SendGravityDirection() != Vector2.down)
            {
                GameManager.Instance.SetGravityInput(GameManager.Gravity.Down);
                TransitionToState(gravityState);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (GameManager.Instance.SendGravityDirection() != Vector2.up)
            {
                GameManager.Instance.SetGravityInput(GameManager.Gravity.Up);
                TransitionToState(gravityState);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (GameManager.Instance.SendGravityDirection() != Vector2.down)
            {
                GameManager.Instance.SetGravityInput(GameManager.Gravity.Left);
                TransitionToState(gravityState);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (GameManager.Instance.SendGravityDirection() != Vector2.right)
            {
                GameManager.Instance.SetGravityInput(GameManager.Gravity.Right);
                TransitionToState(gravityState);
            }
        }

        GameManager.Instance.ChangeGravity();
        currentState.Update(this);
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this);
    }

    

    public void TransitionToState(JeanBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void MoveWithGravity()
    {
        float deplacement = Input.GetAxis("Horizontal");
        if (Vector2.left == GameManager.Instance.SendGravityDirection())
        {
             move = new Vector2(0 , -deplacement);
            this.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (Vector2.right == GameManager.Instance.SendGravityDirection())
        {
             move = new Vector2(0 , deplacement);
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Vector2.up == GameManager.Instance.SendGravityDirection())
        {
             move = new Vector2(-deplacement, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Vector2.down == GameManager.Instance.SendGravityDirection())
        {
             move = new Vector2(deplacement, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
    }
    

    
    
}
