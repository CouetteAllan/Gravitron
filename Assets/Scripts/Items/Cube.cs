using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cube : MonoBehaviour
{
    [SerializeField] private AudioClip land;
    [SerializeField] private AudioClip bigLand;

    [SerializeField] private AudioClip splosh;

    private bool canKill = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<TilemapCollider2D>() != null)
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude > 30)
            {
                AudioManager.Instance.PlayClip(bigLand);
            }
            else
            {
                AudioManager.Instance.PlayClip(land, 0.5f);
            }
        }

        JeanMichelTesteur jean = collision.collider.GetComponent<JeanMichelTesteur>();
        if(jean != null)
        {
            if (canKill)
            {
                AudioManager.Instance.PlayClip(splosh);
                jean.Dead();
            }
        }
    }

    private void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude > 8)
        {
            canKill = true;
        }
        else
        {
            canKill = false;
        }
    }
}
