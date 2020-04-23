using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    public GravityBaseState currentState;
    public readonly GravityDownState gravityDownState = new GravityDownState();
    public readonly GravityLeftState gravityLeftState = new GravityLeftState();
    public readonly GravityRightState gravityRightState = new GravityRightState();
    public readonly GravityUpState gravityUpState = new GravityUpState();

    private void Awake()
    {
        
    }

    void Start()
    {
        TransitionToState(gravityDownState);
    }

    
    void Update()
    {
        currentState.Update(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this);
    }
    public void TransitionToState(GravityBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
