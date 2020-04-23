using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanMichelTesteur : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.ChangeGravity(0, -600);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.ChangeGravity(0, 600);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.ChangeGravity(-600, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.ChangeGravity(600, 0);
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 position = this.rb2d.position;
        position += move * this.speed * Time.deltaTime;
        this.rb2d.MovePosition(position);
    }

    private void ChangeGravity(float x, float y)
    {
        Physics2D.gravity = new Vector2(x, y);
    }
}
