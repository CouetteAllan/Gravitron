using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectileEnergy : MonoBehaviour
{
    [SerializeField] private AudioClip collectible;
    [SerializeField] private float energyLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur player = collision.GetComponent<JeanMichelTesteur>();
        if (player != null)
        {
            UIManager.Instance.ChangeEnergy(energyLevel);
            AudioManager.Instance.Play("CollectibleEnergy");
            Destroy(gameObject);
        }
    }
}
