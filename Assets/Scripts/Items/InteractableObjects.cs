using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    [SerializeField] protected TriggerObjects trigger;


    private void Start()
    {
        ChangeBehaviour();
    }


    public void ChangeBehaviour()
    {
        // Debug.Log("Bouton.Active = " + button.Active);
        if (trigger.Active)
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
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    } 

    protected virtual void DisabledObject()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
