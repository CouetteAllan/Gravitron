﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanMichelTesteur : MonoBehaviour
{
    public JeanBaseState currentState;
    public readonly IdleState idleState = new IdleState();
    public readonly WalkingState walkingState = new WalkingState();
    public readonly JumpingState jumpingState = new JumpingState();
    public readonly GravityState gravityState = new GravityState();

    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;

    private void Awake()
    {

    }

    void Start()
    {
        TransitionToState(idleState);
        rb2d = this.GetComponent<Rigidbody2D>();
    }
    

    
    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
        this.Move();
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

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 position = this.transform.position;
        position += move * this.speed * Time.deltaTime;
        this.transform.position = position;
    }
}
