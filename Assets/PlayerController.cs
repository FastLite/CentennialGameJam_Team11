using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private bool grounded;

    //private bool doubleJumped;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {


        //'GetKeyDown' input will only call once when clicked 
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            //JUMP
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
        }

        //'GetKey' Will continue calling the input as long as the key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            //"to the LEFT to the left"
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
        }
        else
        {
            if (Input.GetKey(KeyCode.A) && !grounded)
            {
                //"to the LEFT to the left"
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, jumpHeight -= 0);
            }



            if (Input.GetKey(KeyCode.D))
            {
                //RIGHT
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            }

        }
    }
}
