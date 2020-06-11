using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : InteractableObjects
{
    [SerializeField] private GameObject[] composants = new GameObject[2];


    protected override void ActivateObject()
    {
        base.ActivateObject();
        foreach (GameObject c in composants)
        {
            c.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    protected override void DisabledObject()
    {
        base.DisabledObject();
        foreach (GameObject c in composants)
        {
            c.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur jean = collision.GetComponent<JeanMichelTesteur>();

        if (jean != null)
        {

            AudioManager.Instance.Play("deadlyLaser");
            jean.Dead(1);
            jean.GetComponent<Animator>().SetTrigger("Desintegrated");
            jean.GetComponent<Animator>().SetBool("Walking", false);
            jean.GetComponent<Animator>().SetBool("Idling", false);
            jean.GetComponent<Animator>().SetBool("Falling", false);
            jean.GetComponent<Animator>().SetBool("Jumping", false);
        }
    }
}
