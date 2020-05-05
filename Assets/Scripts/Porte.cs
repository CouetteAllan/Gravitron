using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    Button button = new Button();
    float moveDistance = 5f;
    private Vector2 targetMovePosition;
    Vector3 movDirHor = new Vector3(1, 0, 0);
    Vector3 movDirVer;

    private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveHorizontal()
    {
        if (button.Active == true)
        {
            
            this.targetMovePosition = transform.position + (moveDistance * movDirHor);
            this.transform.position = Vector2.MoveTowards(this.transform.position, this.targetMovePosition, 50.0f * Time.deltaTime);
            if (Vector3.Distance(this.transform.position, this.targetMovePosition) < 0.05f)
            {
                this.transform.position = this.targetMovePosition;
            }
        }
    }
}
