using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cube : MonoBehaviour
{
    [SerializeField] private AudioClip land;
    [SerializeField] private AudioClip bigLand;

    [SerializeField] private AudioClip splosh;

    private float vitesse;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<TilemapCollider2D>() != null)
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude > 30)
            {
                AudioManager.Instance.Play("bigLand");
            }
            else
            {
                AudioManager.Instance.Play("land");
            }
        }

        /*JeanMichelTesteur jean = collision.collider.GetComponent<JeanMichelTesteur>();
        if(jean != null)
        {
            if (canKill)
            {
               
                jean.GetComponent<Animator>().SetTrigger("Crush");
                jean.GetComponent<Animator>().SetBool("Walking", false);
                jean.GetComponent<Animator>().SetBool("Idling", false);
                jean.GetComponent<Animator>().SetBool("Falling", false);
                jean.GetComponent<Animator>().SetBool("Jumping", false);
                AudioManager.Instance.Play("splosh");
                jean.Dead(0.4f);
                
            }
        }*/
    }
}
