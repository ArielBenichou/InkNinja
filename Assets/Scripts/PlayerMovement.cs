using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool isMoving;
    public Vector2 moveDirection = Vector2.zero;
    public float moveSpeed = 5f;
    [SerializeField]private float movementDeadzone = 0.05f;
    [SerializeField] private float StickDeadzone = 0.2f;
    private Rigidbody2D rb2D;
    private Vector2 lastPos;
    private Vector2 tmp = Vector2.zero;
    bool fire=false;

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

    public void onMove(InputAction.CallbackContext context)
    {
         tmp = context.ReadValue<Vector2>();
    }
    public void onFire(InputAction.CallbackContext context) {
        //fire = context.ReadValue<bool>();
        fire = context.action.triggered;
    }

    // Update is called once per frame
    void Update()
    {

        //float moveX = Input.GetAxis("Horizontal");
        float moveX = tmp.x;
        float moveY = tmp.y;

        //!(-StickDeadzone<moveX && moveX <StickDeadzone)
        bool xtrue = !(-StickDeadzone < moveX && moveX < StickDeadzone);
        bool ytrue = !(-StickDeadzone < moveY && moveY < StickDeadzone);
        Debug.Log(xtrue + "   " + ytrue);


        //if (!isMoving && (moveX != 0 || moveY != 0))
        if (!isMoving && (xtrue || ytrue))
        {
            //moveDirection = (moveX != 0) ?new  Vector2(moveX, 0) : new Vector2(0,moveY);
            if (xtrue)
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
        //if (Input.GetButtonDown("Fire1")) { isMoving = false; moveDirection = Vector2.zero; }
        if (fire) { isMoving = false; moveDirection = Vector2.zero; }
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
