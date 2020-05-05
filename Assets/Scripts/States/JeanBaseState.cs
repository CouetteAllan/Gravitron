using UnityEngine;

public abstract class JeanBaseState 
{
    public abstract void EnterState(JeanMichelTesteur jean);

    public abstract void Update(JeanMichelTesteur jean);

    public abstract void OnCollisionEnter2D(JeanMichelTesteur jean);

    public abstract void OnCollisionStay2D(JeanMichelTesteur jean);
}
