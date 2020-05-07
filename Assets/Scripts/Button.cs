using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool active = false;
    public bool Active
    {
        get { return active; }
        set { active = value; }
    }

    private int directionVectorPorte = 1;
    public int DirectionVectorPorte
    {
        get { return directionVectorPorte; }
        private set { return; }
    }
   
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur jean = collision.GetComponent<JeanMichelTesteur>();
        if(jean != null)
        {
            active = !active;
            directionVectorPorte = - directionVectorPorte;
        }
    }
}
