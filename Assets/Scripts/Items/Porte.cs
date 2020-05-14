using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : InteractableObjects
{
    float moveDistance = 10f;

    private Vector2 targetMovePosition;

    [SerializeField] private float distance = 1;

    [SerializeField] private bool verticalDoor = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.rotation.z >= 0)
        {
            MoveVertical();
        }*/
        
        
        //MoveHorizontal();
        
        
        
    }

    protected override void ActivateObject()
    {
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
        Vector3 movDirHor = new Vector3(dist, 0, 0);
        

        if (button.Active == true)
        {
            this.targetMovePosition = transform.position + (moveDistance * movDirHor);
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.targetMovePosition, 50.0f * Time.deltaTime);
            
            button.Active = false;
        }
    }

    private void MoveVertical(float dist)
    {
        Vector3 movDirVer = new Vector3(0, dist, 0);


        if (button.Active == true)
        {
            this.targetMovePosition = transform.position + (moveDistance * movDirVer);
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.targetMovePosition, 50.0f * Time.deltaTime);
            
            button.Active = false;
        }
    }
}
