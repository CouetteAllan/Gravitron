using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectileEnergy : MonoBehaviour
{
    public bool semi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur player = collision.GetComponent<JeanMichelTesteur>();
        if (player != null)
        {
            UIEnergyScript.Instance.ChangeEnergy(1, semi);
            Destroy(gameObject);
        }
    }
}
