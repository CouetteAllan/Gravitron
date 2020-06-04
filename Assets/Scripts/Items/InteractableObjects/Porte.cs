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

    [SerializeField] private float distance;

    [SerializeField] private bool verticalDoor = false;


    
    void Start()
    {
        pillierTransform = this.GetComponent<Transform>();
        firstPosition = pillierTransform.localPosition;
    }
    
    void Update()
    {
        if (isMoving)
        {
            direction = Vector3.MoveTowards(this.transform.localPosition, targetMovePosition, distance);
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
            if (transform.localPosition.y <= 0)
            {
                pillierTransform.localPosition = firstPosition;
                isMovingBack = false;
            }
        }


    }

    protected override void ActivateObject()
    {
        isMoving = true;
        isMovingBack = false;
        
        MoveVertical(true);
        
        this.GetComponent<Collider2D>().enabled = false;
    }

    protected override void DisabledObject()
    {
        isMovingBack = true;
        isMoving = false;
        
        MoveVertical(false);
        
        this.GetComponent<Collider2D>().enabled = true;
    }

    

    private void MoveVertical(bool directionUp)
    {
        movDir = Vector2.up;
        this.targetMovePosition.y = Mathf.Clamp(pillierTransform.localPosition.y + (distance * movDir.y),0,distance);
    }
}
