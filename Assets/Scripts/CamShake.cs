using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    //Sky
    [SerializeField]
    Animator camAnim;

    public void Shake()
    {
        camAnim.SetTrigger("Shake");
    }
}
