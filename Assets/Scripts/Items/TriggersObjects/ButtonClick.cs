using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : TriggerObjects
{
    /*private int directionVectorPorte = 1;
    public int DirectionVectorPorte
    {
        get { return directionVectorPorte; }
        private set { return; }
    }*/
    [SerializeField]
    private Sprite pressed;
    [SerializeField]
    private Sprite nopressed;

    private SpriteRenderer sRenderer;


    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        JeanMichelTesteur jean = collision.GetComponent<JeanMichelTesteur>();
        if(jean != null)
        {
            if (Input.GetButtonDown("Interact"))
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur jean = collision.GetComponent<JeanMichelTesteur>();
        if(jean != null)
        {
            if (Input.GetButtonDown("Interact"))
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
    }

}
