using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : InteractableObjects
{
    protected override void ActivateObject()
    {
        base.ActivateObject();
        AudioManager.Instance.Stop("Tesla");

    }

    protected override void DisabledObject()
    {
        base.DisabledObject();
        AudioManager.Instance.Play("Tesla");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        JeanMichelTesteur jean = collision.GetComponent <JeanMichelTesteur>();
        if (jean != null)
        {
            jean.Dead(1f);

            jean.GetComponent<Animator>().SetTrigger("Electrified");
            jean.GetComponent<Animator>().SetBool("Walking", false);
            jean.GetComponent<Animator>().SetBool("Idling", false);
            jean.GetComponent<Animator>().SetBool("Falling", false);
            jean.GetComponent<Animator>().SetBool("Jumping", false);
            AudioManager.Instance.Stop("Tesla");
            AudioManager.Instance.Play("Bzzt");
        }
    }
}
