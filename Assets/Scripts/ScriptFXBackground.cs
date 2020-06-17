using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFXBackground : MonoBehaviour //sert à tourner les petits courant d'air dans le sens de la gravité
{
    // -------------------------------- Allan -----------------------
    private float transformRotationZ;

    void Start()
    {
        this.transformRotationZ = GetComponent<Transform>().rotation.z;
    }
    void Update()
    {
        ChangeRotation();
    }

    private void ChangeRotation()
    {
        if (Vector2.left == GameManager.Instance.SendGravityDirection())
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Vector2.right == GameManager.Instance.SendGravityDirection())
        {
            this.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (Vector2.up == GameManager.Instance.SendGravityDirection())
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Vector2.down == GameManager.Instance.SendGravityDirection())
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
