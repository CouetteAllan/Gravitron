using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjects : MonoBehaviour
{
    [SerializeField] private InteractableObjects[] activableObjects;


    [SerializeField] protected bool active = false;
    public bool Active
    {
        get { return active; }
        set { active = value; }
    }


    protected virtual void Snap()
    {
        foreach (InteractableObjects activableObject in activableObjects)
        {
            activableObject.ChangeBehaviour();
        }
    }
}
