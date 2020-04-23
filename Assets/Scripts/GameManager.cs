using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 gravity;

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
        gravity = Physics2D.gravity;
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.ChangeGravity(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.ChangeGravity(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.ChangeGravity(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.ChangeGravity(Vector2.right);
        }
    }


    public void ChangeGravity(Vector2 newGravity)
    {
        this.gravity = newGravity * gravity;
    }
}
