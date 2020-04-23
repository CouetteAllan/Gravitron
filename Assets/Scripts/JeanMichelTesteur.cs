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
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, 0);
        Vector2 position = this.rb2d.position;
        position += move * this.speed * Time.deltaTime;
        this.rb2d.MovePosition(position);
    }
}
