using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float moveInput;

    private int extraJumps;
    public int extraJumpValue;

    private Rigidbody2D rb;

    private bool facingRight = true;

    
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
        if(facingRight == false && moveInput > 0)
        {
            Flip();
            Debug.Log(facingRight+ "I flipped left");
        }else if(facingRight == true && moveInput < 0)
        {
            Flip();
            Debug.Log(facingRight + "I flipped right");
        }

        if(rb.velocity.x > 0 || rb.velocity.x < 0)
        {
            playerAnim.SetBool("isMoving", true);
        }
        else if(rb.velocity.x == 0)
        {
            playerAnim.SetBool("isMoving", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;

        }else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded){
            rb.velocity = Vector2.up * jumpForce;

        }
    }
}
