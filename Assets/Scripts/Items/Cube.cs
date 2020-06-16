﻿using System.Collections;
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
    }
}
