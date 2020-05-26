using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : TriggerObjects
{
    [SerializeField] private Sprite PlaquePression;
    [SerializeField] private Sprite PlaquePressee;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cube cube = collision.GetComponent<Cube>();
        if (cube != null)
        {
            Active = true;
            Snap();
            GetComponent<SpriteRenderer>().sprite = PlaquePressee;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Cube cube = collision.GetComponent<Cube>();
        if (cube != null)
        {
            Active = false;
            Snap();
            GetComponent<SpriteRenderer>().sprite = PlaquePression; 
        }
    }
}
