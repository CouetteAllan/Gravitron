using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : InteractableObjects
{
    [SerializeField]
    private AudioClip deadlyLaser;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur jean = collision.GetComponent<JeanMichelTesteur>();

        if (jean != null)
        {

            AudioManager.Instance.PlayClip(deadlyLaser);
            jean.Dead(1);
            jean.GetComponent<Animator>().SetTrigger("Desintegrated");
        }
    }
}
