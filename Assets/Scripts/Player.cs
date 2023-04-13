using UnityEngine;
using System;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TilePainter))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [Header("Stats:")]
    public string pName = "gray";
    public Color pColor = Color.gray;
    [Range(1, 40)]
    public float pSpeed = 15f;
    [HideInInspector] public PowerBar powerBar;

    [Header("debug")]
    public bool isMoving;
    public Vector2 moveDirection = Vector2.zero;

    [Space(10)]
    [Tooltip("how much player has to move every frame in order to count as moving.")]
    [SerializeField] private float movementDeadzone = 0.05f;
    [SerializeField] private float StickDeadzone = 0.2f;


    private Rigidbody2D rb2D;
    private Vector2 lastPos = Vector2.zero;
    private Vector2 AxisInput = Vector2.zero;
    private Vector2 startPos = Vector2.zero;
    private Vector2 slashVelocity = Vector2.zero;
    private bool canSlash = true;
    [HideInInspector] private bool slashing = false;

    private AudioManager audioManager;




    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        PlayerManager.addPlayer(gameObject);
        audioManager = FindObjectOfType<AudioManager>();
        AxisInput = Vector2.zero;
        lastPos = transform.position;
        isMoving = false;



    }

    //----------MOVEMENT----------
    private void Update()
    {
        float moveX = AxisInput.x;
        float moveY = AxisInput.y;

        bool xtrue = !(-StickDeadzone < moveX && moveX < StickDeadzone);
        bool ytrue = !(-StickDeadzone < moveY && moveY < StickDeadzone);

        if (!isMoving && (xtrue || ytrue) && !slashing)
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
    }
    private void FixedUpdate()
    {
        Vector2 velocity;
        // do we want this ?? if ((transform.position.x - startPos.x)+(transform.position.y - startPos.y) > 7) { Debug.Log("ended slash early"); slashing = false; }
        if (Mathf.Abs(Vector2.Distance(lastPos, transform.position)) < movementDeadzone)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
            //if (slashing) Invoke("StopRun",1.0f);
        }
        if (!slashing)
        {
            velocity = new(moveDirection.normalized.x * pSpeed, moveDirection.normalized.y * pSpeed);
        }
        else
        {
            velocity = slashVelocity;
        }
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);

        lastPos = transform.position;
    }
    public void onMove(InputAction.CallbackContext context)
    {
        AxisInput = context.ReadValue<Vector2>();
    }
    //----------DASHSLASH----------
    public void Onfire(InputAction.CallbackContext context)
    {
        //context.action.triggered;
        if (canSlash)
        {

            if (powerBar.UsePowerBar())
            {
                SlashForward(7);
                //audioManager.Play("Run");
            }
            else
            {
                Debug.Log("cannot fire not enough fill");
                audioManager.Play("SkillError");
            }
            canSlash = false;
            Invoke("resetSlash", 2.0f);
        }

    }
    public void SlashForward(float distance = 7)
    {

        startPos = transform.position;
        slashVelocity = new(moveDirection.normalized.x * pSpeed * 3, moveDirection.normalized.y * pSpeed * 3);
        slashing = true;
        Invoke("endSlash", 1.0f);


    }
    private void StopRun()
    {
        audioManager.Stop("Run",0);
    }
    private void endSlash()
    {
        slashing = false;
    }
    private void resetSlash()
    {
        canSlash = true;
    }
    //----------COLLISION HANDLING----------
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() && slashing)
        {


            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;


            audioManager.Stop("Run",0);
            audioManager.Play("Slash");
            //collision.gameObject.SetActive(false);
            //destroy(Player);
        }
    }
    public void ResetPlayer(Player player)
    {
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<Rigidbody2D>().simulated = true;
    }




}
