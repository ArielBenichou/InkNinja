using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Vector2 moveDirection = Vector2.zero;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Fire1")) { isMoving = false; moveDirection = Vector2.zero; }
        if (!isMoving&&(moveX!=0 || moveY != 0))
        {
            //moveDirection = (moveX != 0) ?new  Vector2(moveX, 0) : new Vector2(0,moveY);
            if (moveX != 0)
            {
                moveDirection = new Vector2(moveX, 0);
            }
            else
            {
                moveDirection = new Vector2(0, moveY);
            }
            isMoving = true;
            //transform.forward = moveDirection; 
        }
    }
    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(moveDirection.normalized.x * moveSpeed, moveDirection.normalized.y * moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {



        Vector2 normal =collision.contacts[0].normal;
        if (collision.gameObject.CompareTag("Wall"))
        {
            if ((normal.x * -1 == moveDirection.normalized.x && moveDirection.normalized.x != 0) || (normal.y * -1 == moveDirection.normalized.y && moveDirection.normalized.y != 0))
            {
                moveDirection = new Vector2(0, 0);
                isMoving = false;
                Debug.Log("YAY");
            }
        }
        //Debug.Log("Dx:" + moveDirection.normalized.x+" NX:"+ normal.x * -1 + " DY:" + moveDirection.normalized.y + " NY:"+ normal.y * -1);


        
           
        
    }

}
