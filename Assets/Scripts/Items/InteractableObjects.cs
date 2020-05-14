using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    [SerializeField] protected Button button;



    public void ChangeBehaviour()
    {
        if (button.Active)
        {
            ActivateObject();
        }
        else
        {
            DisabledObject();
        }
    }

    protected virtual void ActivateObject()
    {

    } 

    protected virtual void DisabledObject()
    {

    }
}
