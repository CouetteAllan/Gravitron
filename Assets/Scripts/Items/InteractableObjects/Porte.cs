using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : InteractableObjects
{

    private Vector3 targetMovePosition;
    private Vector3 movDir;
    private Vector3 firstPosition;
    private Vector3 direction;
    private bool isMovingBack;
    Transform pillierTransform;

    [SerializeField] private bool reversed = false;

    [SerializeField] private float distance;

    [SerializeField] private bool verticalDoor = false;


    
    void Start()
    {
        pillierTransform = this.GetComponent<Transform>();
        firstPosition = pillierTransform.localPosition;
        if (reversed) //si la porte doit être inversée (elle est ouverte de base)
        {
            pillierTransform.localPosition = new Vector3(0, distance - 1.7f, 0); //alors sa position est sa position finale en mode normale avec un petit différentiel sinon ça bug et la porte s'en va
        }
    }
    
    void Update()
    {
        direction = Vector3.MoveTowards(this.transform.localPosition, targetMovePosition, distance);// définit vers où s'ouvre la porte
        if (isMoving)//petit flag toi même tu sais car c'est dans un update et pour éviter que le mouvement se fasse sans qu'on le demande
        {
            Vector3 position = pillierTransform.localPosition;//la porte
            position +=  direction * Time.deltaTime;          //bouge
            pillierTransform.localPosition = position;       //vers le point d'arriver (elle s'ouvre)
            if ( Vector3.Distance(pillierTransform.localPosition,targetMovePosition) <= 0.2) //quand elle atteint sa destination elle s'arrête
            {
                pillierTransform.localPosition = targetMovePosition;
                isMoving = false;
            }
        }
        if (isMovingBack)
        { // le même movement mais inversé
            Vector3 position = pillierTransform.localPosition;
            position +=  -direction * Time.deltaTime;
            pillierTransform.localPosition = position;
            if (transform.localPosition.y <= 0.7)
            {
                pillierTransform.localPosition = firstPosition;
                isMovingBack = false;
            }
        }


    }

    protected override void ActivateObject()
    {
        if (!reversed)
        {
            isMoving = true;
            isMovingBack = false;
            this.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            isMovingBack = true;
            isMoving = false;
            this.GetComponent<Collider2D>().enabled = true;
        }

        MoveVertical();
        AudioManager.Instance.Play("door");
        
    }

    protected override void DisabledObject()
    {
        if (!reversed)
        {
            isMoving = false;
            isMovingBack = true;
            this.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            isMovingBack = false;
            isMoving = true;
            this.GetComponent<Collider2D>().enabled = false;
        }
        MoveVertical();
        AudioManager.Instance.Play("door");


    }

    

    private void MoveVertical()
    {
        movDir = Vector2.up;
        this.targetMovePosition.y = Mathf.Clamp(pillierTransform.localPosition.y + (distance * movDir.y),0,distance);
    }
}
