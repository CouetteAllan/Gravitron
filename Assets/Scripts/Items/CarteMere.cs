using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarteMere : MonoBehaviour
{
    [SerializeField] private GameObject halo;
    public float aura;
    public float amplitude;


    [SerializeField]
    private Text cacahuete;
    public bool collected = false;

    private void Update()
    {
        float haloScale = aura + Mathf.Sin(Time.timeSinceLevelLoad) * amplitude;
        halo.transform.localScale = new Vector3(haloScale, haloScale, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur jean = collision.GetComponent<JeanMichelTesteur>();
        if (jean != null)
        {
            collected = true;
            if (collected == true)
            {
                cacahuete.text = "Oui!";

            }
            Destroy(gameObject);
        }
    }

}
