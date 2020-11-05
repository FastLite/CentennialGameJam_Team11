using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GhostController : MonoBehaviour
{
    public float ghostSpeed;
    public Rigidbody2D rbGhost;
   // public KeyCode immaterial;
   

    private Vector2 moveDirection;
    
    
    public GameObject spiderPrefab;
    public GameObject wormPrefab;

    public GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
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

    
    
    
    Component CopyComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        // Copied fields can be restricted with BindingFlags
        System.Reflection.FieldInfo[] fields = type.GetFields(); 
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("I should collide creature " + other.gameObject.name);


        if (Input.GetKeyDown("e") && gm.currentScene == 1)
        {
            GameObject gm = Instantiate(spiderPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        else if (Input.GetKeyDown("e") && gm.currentScene == 2)
        {
            GameObject gm = Instantiate(wormPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        return;
        
            
            
        //Debug.Log("I should posses creature " + other.gameObject.name);
    }
}
