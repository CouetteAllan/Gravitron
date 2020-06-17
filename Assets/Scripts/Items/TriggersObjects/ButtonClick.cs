using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : TriggerObjects
{
    // ---------------- Allan ------------
    [SerializeField]
    private Sprite pressed;
    [SerializeField]
    private Sprite nopressed;

    private SpriteRenderer sRenderer;

    private bool canBePressed;//booléen pour savoir si on peut presser le bouton 


    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(canBePressed && Input.GetButtonDown("Interact"))//Si on appuie sur E et qu'on est à côté du bouton
        {
            Snap();

            if (sRenderer.sprite != pressed)
            {
                this.GetComponent<SpriteRenderer>().sprite = pressed;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = nopressed;
            }

            AudioManager.Instance.Play("click");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)   //Détecte si on est dans la range du bouton
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canBePressed = true;      //Jean-Michel est dans la range donc il peut presser le bouton
        }
    }
    private void OnTriggerExit2D(Collider2D collision)   //Détecte si on sort de la range du bouton
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canBePressed = false;     //Jean-Michel n'est plus dans la range donc il ne peut plus presser le bouton
        }
    }

}
