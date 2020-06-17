using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectileEnergy : MonoBehaviour
{
    // Emile
    [SerializeField] private float energyLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur player = collision.GetComponent<JeanMichelTesteur>();
        if (player != null)
        {
            UIManager.Instance.ChangeEnergy(energyLevel);
            if (energyLevel > 0.5f)
            {
                AudioManager.Instance.Play("CollectibleEnergy");
            }
            else
            {
                AudioManager.Instance.Play("SemiCollectibleEnergy");

            }
            Destroy(gameObject);
        }
    }
}
