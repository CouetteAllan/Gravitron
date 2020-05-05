using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 localGravity;
    [SerializeField]
    private string gravityInputDirection = "down";

    private Vector2 direction;

    

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Le GameManager est null lulz");
            }
            return instance;
        }
    }

    private void Awake()
    {
        Debug.Log(Physics2D.gravity.magnitude);
        instance = this;
        localGravity = Physics2D.gravity;
    }

    
    public void ChangeGravity()
    {
        switch (gravityInputDirection)
        {
            case "up":
                direction = Vector2.up;
                Debug.Log("UP");
                break;
            case "left":
                direction = Vector2.left;
                Debug.Log("LEFT");
                break;
            case "right":
                direction = Vector2.right;
                Debug.Log("RIGHT");
                break;
            case "down":
                direction = Vector2.down;
                Debug.Log("DOWN");
                break;
            default:
                direction = Vector2.down;
                Debug.Log("No Gravity");
                break;
        }
        Physics2D.gravity = direction * localGravity.magnitude;
        this.localGravity = Physics2D.gravity;//change la gravité
    }

    public Vector2 SendGravityDirection()
    {
        Vector2 gravityDirection = this.localGravity.normalized ;
        return gravityDirection;
    }

    public void GetGravityInput(string input)
    {
        this.gravityInputDirection = input;
    }


}