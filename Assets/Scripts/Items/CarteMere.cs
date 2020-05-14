using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarteMere : MonoBehaviour
{
    [SerializeField]
    private Text cacahuete;
    private bool collected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool collected = true;
        if (collected == true)
        {
            cacahuete.text = "Oui!";
        }
        Destroy(gameObject);
    }
}
