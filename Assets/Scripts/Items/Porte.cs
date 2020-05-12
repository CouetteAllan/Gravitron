using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    [SerializeField]
    private Button button = null;

    float moveDistance = 10f;

    private Vector2 targetMovePosition;
    



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
        
        
        MoveHorizontal();
        
        
        
    }

    private void MoveHorizontal()
    {
        Vector3 movDirHor = new Vector3(button.DirectionVectorPorte, 0, 0);
        

        if (button.Active == true)
        {
            this.targetMovePosition = transform.position + (moveDistance * movDirHor);
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.targetMovePosition, 50.0f * Time.deltaTime);
            
            button.Active = false;
        }
    }

    private void MoveVertical()
    {
        Vector3 movDirVer = new Vector3(0, button.DirectionVectorPorte, 0);


        if (button.Active == true)
        {
            this.targetMovePosition = transform.position + (moveDistance * movDirVer);
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.targetMovePosition, 50.0f * Time.deltaTime);
            
            button.Active = false;
        }
    }
}
