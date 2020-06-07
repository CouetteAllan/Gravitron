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
            Snap();
            GetComponent<SpriteRenderer>().sprite = PlaquePressee;
            GetComponent<BoxCollider2D>().size = new Vector2(7.6f, 0.5f);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Cube cube = collision.GetComponent<Cube>();
        if (cube != null)
        {
            Snap();
            GetComponent<SpriteRenderer>().sprite = PlaquePression;
            GetComponent<BoxCollider2D>().size = new Vector2(7.6f, 2f);
            
        }
    }
}
