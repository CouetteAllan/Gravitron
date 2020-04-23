using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanMichelTesteur : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump;
    private bool isJumping = true;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(isJumping);
            if (!isJumping)
            {
                isJumping = true;
                this.Jump();
            }
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 position = this.transform.position;
        position += move * this.speed * Time.deltaTime;
        this.transform.position = position;
    }

    private void Jump()
    {
        this.rb2d.AddForce(Vector2.up * jump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
