using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private InteractableObjects activableObject;

    private bool active = false;
    public bool Active
    {
        get { return active; }
        set { active = value; }
    }

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
                Debug.Log("Avant pression : active = " + active);
                active = !active;
                Debug.Log("Avant pression : active = " + active);
                //directionVectorPorte = - directionVectorPorte;
                OnButtonClick(ref active);
            }
        }
    }

    public void OnButtonClick(ref bool active)
    {
        activableObject.ChangeBehaviour();
    }
}
