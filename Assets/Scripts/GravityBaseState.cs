
using UnityEngine;

public abstract class GravityBaseState : MonoBehaviour
{
    public abstract void EnterState(GravityController gravity);

    public abstract void Update(GravityController gravity);

    public abstract void OnCollisionEnter2D(GravityController gravity);
}
