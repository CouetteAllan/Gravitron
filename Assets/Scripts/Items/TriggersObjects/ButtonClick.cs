using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : TriggerObjects
{ 
    /*private int directionVectorPorte = 1;
    public int DirectionVectorPorte
    {
        get { return directionVectorPorte; }
        private set { return; }
    }*/
   


    private void OnTriggerStay2D(Collider2D collision)
    {
        JeanMichelTesteur jean = collision.GetComponent<JeanMichelTesteur>();
        if(jean != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                active = !active;
                Debug.Log("Bouton préssé, " + Active);
                //directionVectorPorte = - directionVectorPorte;
                Snap();
            }
        }
    }
}
