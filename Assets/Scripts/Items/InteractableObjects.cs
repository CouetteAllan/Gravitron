using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    [SerializeField] protected ButtonClick button;



    public void ChangeBehaviour()
    {
        // Debug.Log("Bouton.Active = " + button.Active);
        if (button.Active)
        {
            ActivateObject();
            // Debug.Log("Objet Activé");
        }
        else
        {
            DisabledObject();
            // Debug.Log("Objet Désactivé");
        }
    }

    protected virtual void ActivateObject()
    {

    } 

    protected virtual void DisabledObject()
    {

    }
}
