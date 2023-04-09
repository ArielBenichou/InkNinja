using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float movementDeadzone = 0.05f;
    Vector2 moveDirection = Vector2.zero;
    public Rigidbody2D rb2D;
    public float moveSpeed = 5f;
    public bool isMoving;
    private Vector2 lastPos;

    // Start is called before the first frame update
    private void Awake()
    {
        //rb2D = gameObject.AddComponent<Rigidbody2D>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        lastPos = transform.position;
        isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (!isMoving && (moveX != 0 || moveY != 0))
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
            //isMoving = true;
            //transform.forward = new Vector3(0,0,1); 
        }
        if (Input.GetButtonDown("Fire1")) { isMoving = false; moveDirection = Vector2.zero; }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(Vector2.Distance(lastPos, transform.position)) < movementDeadzone) isMoving = false;
        else isMoving = true;
        Vector2 velocity = new(moveDirection.normalized.x * moveSpeed, moveDirection.normalized.y * moveSpeed);
        //rb2D.velocity = velocity;
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
        //rb.velocity = new Vector2(moveDirection.normalized.x * moveSpeed, moveDirection.normalized.y * moveSpeed);
        lastPos = transform.position;

    }


    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Vector2 normal = collision.contacts[0].normal;
    //    foreach (ContactPoint2D contact in collision.contacts)
    //    {
    //        Vector2 normal = contact.normal;
    //        if (collision.gameObject.CompareTag("Wall"))
    //        {
    //            Debug.Log(normal.x + "   " + normal.y + "    x:" + collision.collider.transform.position.x + "    y:" + collision.collider.transform.position.y);
    //            if ((normal.x * -1 == moveDirection.normalized.x && moveDirection.normalized.x != 0) || (normal.y * -1 == moveDirection.normalized.y && moveDirection.normalized.y != 0))
    //            {
    //                Debug.Log("<color=green>YAY</color>");
    //            }
    //        }
    //    }
    //    //Debug.Log("Dx:" + moveDirection.normalized.x+" NX:"+ normal.x * -1 + " DY:" + moveDirection.normalized.y + " NY:"+ normal.y * -1);
    //}

}
