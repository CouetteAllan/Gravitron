using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    [SerializeField] protected TriggerObjects trigger;
    protected bool activated;


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
        else if (!trigger.Active)
        {
            DisabledObject();
            // Debug.Log("Objet Désactivé");
        }
    }

    protected virtual void ActivateObject()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    } 

    protected virtual void DisabledObject()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
