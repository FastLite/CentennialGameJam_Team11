using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GhostController : MonoBehaviour
{
    public float ghostSpeed;
    public Rigidbody2D rbGhost;
   // public KeyCode immaterial;

    private Vector2 moveDirection;
    
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
    }

     void FixedUpdate()
    {
        Move();   
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    void Move() // Method the control the Playeer's Ghost movement
    {
        rbGhost.velocity = new Vector2(moveDirection.x * ghostSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if(collision.gameObject.name == "Wall)")
        {
            if(collision.gameObject.CompareTag("Wall"))
            {
                GetComponent<CircleCollider2D>().isTrigger = false;
                Debug.Log(gameObject + "Hit the wall");
            }
            if(collision.gameObject.name == "MonsterA")
            {
                GetComponent<mcController>();
                gameObject.SetActive(false);
            }
           
        }
    }

    //  private void OnTriggerEnter2D(Collider2D hitInfo)
    //  {
    //
    //      rbGhost.velocity = new Vector2(moveDirection.x * 0, moveDirection.y * 0);
    //  }
}
