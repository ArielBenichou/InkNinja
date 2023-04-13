using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Header("debug")]
    public bool isMoving;
    public Vector2 moveDirection = Vector2.zero;

    [Space(10)]
    [Tooltip("how much player has to move every frame in order to count as moving.")]
    [SerializeField] private float movementDeadzone = 0.05f;
    [SerializeField] private float StickDeadzone = 0.2f;

    
    private Rigidbody2D rb2D;
    private Vector2 lastPos=Vector2.zero;
    private Vector2 AxisInput = Vector2.zero;
    private bool fire = false;
    private Vector2 startPos= Vector2.zero;
    private PlayerStats playerStats;
    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
        


        lastPos = transform.position;
        isMoving = false;

    }

    public void onMove(InputAction.CallbackContext context)
    {
        AxisInput = context.ReadValue<Vector2>();
    }
    public void onFire(InputAction.CallbackContext context)
    {
        //fire = context.ReadValue<bool>();
        fire = context.action.triggered;
    }

    void Update()
    {

        float moveX = AxisInput.x;
        float moveY = AxisInput.y;

        bool xtrue = !(-StickDeadzone < moveX && moveX < StickDeadzone);
        bool ytrue = !(-StickDeadzone < moveY && moveY < StickDeadzone);

        if (!isMoving && (xtrue || ytrue) && !playerStats.slashing)
        {
            if (xtrue)
            {
                moveDirection = new Vector2(moveX, 0);
            }
            else
            {
                moveDirection = new Vector2(0, moveY);
            }
             
        }
        if (fire) { moveDirection = Vector2.zero; }
    }

    private void FixedUpdate()
    {
        Vector2 velocity;
        // do we want this ?? if ((transform.position.x - startPos.x)+(transform.position.y - startPos.y) > 7) { Debug.Log("ended slash early"); slashing = false; }
        if (!playerStats.slashing)
        {
            if (Mathf.Abs(Vector2.Distance(lastPos, transform.position)) < movementDeadzone) { isMoving = false; }
            else { isMoving = true; }
            velocity = new(moveDirection.normalized.x * playerStats.pSpeed, moveDirection.normalized.y * playerStats.pSpeed);
            //rb2D.velocity = velocity;
        }
        else
        {   
            velocity = new(moveDirection.normalized.x * playerStats.pSpeed * 3, moveDirection.normalized.y * playerStats.pSpeed * 3);
        }
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);

        //rb.velocity = new Vector2(moveDirection.normalized.x * moveSpeed, moveDirection.normalized.y * moveSpeed);
        lastPos = transform.position;

    }
    public void SlashForward(float distance = 7)
    {
        
        startPos = transform.position;
        playerStats.slashing = true;
        Invoke("endSlash", 1.0f);


        //after 1 second slashing = false;
    }
    private void endSlash()
    {
        playerStats.slashing = false;
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

    //var p1 = PlayerInput.Instantiate(playerPrefab,
    //    controlScheme: "KeyboardLeft", device: Keyboard.current);
    //var p2 = PlayerInput.Instantiate(playerPrefab,
    //    controlScheme: "KeyboardRight", device: Keyboard.current);






}
