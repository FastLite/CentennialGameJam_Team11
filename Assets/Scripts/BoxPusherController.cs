using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPusherController : MonoBehaviour
{
    public float boxPusherSpeed;
    public float moveInput;
    public Rigidbody2D rbBoxPusher;
    // public KeyCode immaterial;

    public Animator boxPusherAnim;

    private Vector2 moveDirection;

    private bool facingRight = true;

    private void Start()
    {
        rbBoxPusher = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        // if (Input.GetKeyDown(immaterial))
        // {
        //     GetComponent<Rigidbody2D>().gravityScale = 0;
        //     GetComponent<CircleCollider2D>().isTrigger = true;
        //
        // }
        moveInput = Input.GetAxis("Horizontal");
        if (facingRight == false && moveInput > 0)
        {
            Flip();
            Debug.Log(facingRight + "I flipped left");
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
            Debug.Log(facingRight + "I flipped right");
        }
    }

    void FixedUpdate()
    {
        Move();

        if (rbBoxPusher.velocity.x > 0 || rbBoxPusher.velocity.x < 0)
        {
            boxPusherAnim.SetBool("isMoving", true);
        }
        else if (rbBoxPusher.velocity.x == 0)
        {
            boxPusherAnim.SetBool("isMoving", false);
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    void Move() // Method the control the Playeer's Ghost movement
    {
        rbBoxPusher.velocity = new Vector2(moveDirection.x * boxPusherSpeed, 0);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
