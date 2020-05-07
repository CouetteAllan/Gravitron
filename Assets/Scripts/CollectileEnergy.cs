using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectileEnergy : MonoBehaviour
{
    [SerializeField] private AudioClip collectible;
    [SerializeField] private bool semi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur player = collision.GetComponent<JeanMichelTesteur>();
        if (player != null)
        {
            UIManager.Instance.ChangeEnergy(1, semi);
            AudioManager.Instance.PlayClip(collectible, 0.1f);
            Destroy(gameObject);
        }
    }
}
