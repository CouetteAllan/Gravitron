using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : InteractableObjects
{
    float moveDistance = 10f;

    private Vector3 targetMovePosition;
    private Vector3 movDir;

    [SerializeField] private float distance;

    [SerializeField] private bool verticalDoor = false;

    [SerializeField] private GameObject pillier;
    
    void Start()
    {

    }
    
    void Update()
    {
        if (activated)
        {
            Vector2 position = pillier.transform.position;
            position += Vector2.MoveTowards(this.transform.position, this.targetMovePosition, 5 * Time.deltaTime) * 2 * Time.deltaTime;
            pillier.transform.position = position;
        }



    }

    protected override void ActivateObject()
    {
        activated = true;
        if (verticalDoor)
        {
            MoveVertical(distance);
        }
        else
        {
            MoveHorizontal(distance);
        }
    }

    protected override void DisabledObject()
    {
        activated = false;
        if (verticalDoor)
        {
            MoveVertical(-distance);
        }
        else
        {
            MoveHorizontal(-distance);
        }
    }


    private void MoveHorizontal(float dist)
    {
        Vector3 movDir = new Vector3(dist, 0, 0);


        this.targetMovePosition = pillier.transform.position + (moveDistance * movDir);
    }

    private void MoveVertical(float dist)
    {
        Vector3 movDir = new Vector3(0, dist, 0);
        
        this.targetMovePosition = pillier.transform.position + (moveDistance * movDir);
    }
}
