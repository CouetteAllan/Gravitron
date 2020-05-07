using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    [SerializeField]
    private Button button = null;

    float moveDistance = 5f;

    private Vector2 targetMovePosition;
    //Vector3 movDirVer = new Vector3(0, button.DirectionVectorPorte, 0);



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MoveHorizontal();
        
    }

    private void MoveHorizontal()
    {
        Vector3 movDirHor = new Vector3(button.DirectionVectorPorte, 0, 0);
        

        if (button.Active == true)
        {
            this.targetMovePosition = transform.position + (moveDistance * movDirHor);
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.targetMovePosition, 50.0f * Time.deltaTime);
            if (Vector3.Distance(this.transform.position, this.targetMovePosition) < 0.05f)
            {
                this.transform.position = this.targetMovePosition;
            }
            button.Active = false;
        }
    }
}
