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
        if (reversed)
        {
            pillierTransform.localPosition = new Vector3(0, distance, 0);
        }
    }
    
    void Update()
    {
        direction = Vector3.MoveTowards(this.transform.localPosition, targetMovePosition, distance);
        if (isMoving)
        {
            Vector3 position = pillierTransform.localPosition;
            position +=  direction * Time.deltaTime;
            pillierTransform.localPosition = position;
            if ( Vector3.Distance(pillierTransform.localPosition,targetMovePosition) <= 0.05)
            {
                pillierTransform.localPosition = targetMovePosition;
                isMoving = false;
            }
        }
        if (isMovingBack)
        {
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

        MoveVertical(true);
        
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
        MoveVertical(false);
        
        
    }

    

    private void MoveVertical(bool directionUp)
    {
        movDir = Vector2.up;
        this.targetMovePosition.y = Mathf.Clamp(pillierTransform.localPosition.y + (distance * movDir.y),0,distance);
    }
}
