using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanMichelTesteur : MonoBehaviour
{
    [HideInInspector]
    public JeanBaseState currentState;
    public readonly IdleState idleState = new IdleState();
    public readonly WalkingState walkingState = new WalkingState();
    public readonly JumpingState jumpingState = new JumpingState();
    public readonly GravityState gravityState = new GravityState();

    [SerializeField]
    private float speed;
    public float Speed
    {
        get { return speed; }
    }
    [SerializeField]
    private float jump = 400;
    public float Jump
    {
        get { return jump; }
    }
    private bool isJumping = true;

    private Rigidbody2D rb2d;
    public Rigidbody2D Rigidbody2D
    {
        get { return rb2d; }
    }

    private void Awake()
    {

    }

    void Start()
    {
        TransitionToState(idleState);
        rb2d = this.GetComponent<Rigidbody2D>();
    }
    
    
    void Update()
    {
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
    
    
}
