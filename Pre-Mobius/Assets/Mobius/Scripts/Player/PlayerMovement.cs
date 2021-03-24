using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Estados
    enum PlayerState { Walking, Running, Crouching };

    //Variables del player
    [SerializeField] PlayerState currentState;
    Rigidbody rb;


    [Tooltip("Estatura normal del player")]
    [SerializeField] float normalHeight = 0;
    [Tooltip("Estatura del jugador al agacharse")]
    [SerializeField] float crouchingHeight = 0;

    [Tooltip("Desaceleracion al dejar de moverse")]
    [SerializeField] float deaccelerationSpeed = 15.0f;

    [Tooltip("Velocidad de aceleracion al comenzar a moverse")]
    [SerializeField] float accelerationSpeed = 50000.0f;

    [Tooltip("Velocidad a la que se mueve el jugador")]
    [SerializeField] int maxSpeed = 5;


    [SerializeField] float staminaDecreaseRate = 1f;



    [Tooltip("Fuerza de salto")]
    [SerializeField] float jumpForce = 0f;

    [Tooltip("Fuerza con la que caes si no estas tocando el suelo")]
    [SerializeField] float fallForce = 0f;

    private Vector3 slowdownV;
    private Vector2 horizontalMovement;

    [Tooltip("Si el jugador esta o no tocando el suelo")]
    [SerializeField] bool grounded;

    [Tooltip("Stamina actual del jugador")]
    public float stamina;
    [Tooltip("Stamina maxima del jugador")]
    [SerializeField] float maxStamina = 100;
    [Tooltip("Si el jugador esta gastando stamina")]
    [SerializeField] float staminaRegenerationRate = 1;







    public float InputH;
    public float InputV;



    //Variables de Raycast
    Transform camTransform;
    Ray playerSight;
    Ray rGround;
    [Tooltip("GroundHit")]
    RaycastHit gHit;
    Transform Player;




    void Awake()
    {

        Player = GetComponent<Transform>();
        camTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }



    private void Start()
    {
        stamina = maxStamina;


    }
    void FixedUpdate()
    {
        Movement();
    }




    private void Update()
    {
        InputH = Input.GetAxis("Horizontal");
        InputV = Input.GetAxis("Vertical");



        playerSight = new Ray(camTransform.position, camTransform.forward);
        Debug.DrawRay(playerSight.origin, playerSight.direction * 4, Color.red);
        PlayerStates();
        Jumping();
        Crouching();
        Run();



        GroundDetect();
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }

    }


    void PlayerStates()
    {


        if (currentState == PlayerState.Walking)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new UnityEngine.Vector3(1f, normalHeight, 1f), Time.deltaTime * 15);
            maxSpeed = 5;
        }
        else if (currentState == PlayerState.Crouching)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new UnityEngine.Vector3(1, crouchingHeight, 1), Time.deltaTime * 15);
            maxSpeed = 1;
        }
        else if (currentState == PlayerState.Running)
        {
            stamina -= Time.deltaTime * staminaDecreaseRate;
            maxSpeed = 7;
        }
        else
        {
            currentState = PlayerState.Walking;
        }



    }

    void Movement()
    {
        horizontalMovement = new Vector2(rb.velocity.x, rb.velocity.z);
        if (horizontalMovement.magnitude > maxSpeed)
        {
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement *= maxSpeed;
        }

        rb.velocity = new Vector3(
            horizontalMovement.x,
            rb.velocity.y,
            horizontalMovement.y
            );

        if (grounded)
        {
            rb.velocity = Vector3.SmoothDamp(
                rb.velocity,
                new Vector3(0, rb.velocity.y, 0),
                ref slowdownV,
                deaccelerationSpeed
                );
        }
        if (grounded)
        {
            rb.AddRelativeForce(InputH * accelerationSpeed * Time.deltaTime, 0, InputV * accelerationSpeed * Time.deltaTime);
        }
        else
        {
            rb.AddRelativeForce(InputH * accelerationSpeed / 2 * Time.deltaTime, 0, InputV * accelerationSpeed / 2 * Time.deltaTime);
        }

        if (InputH != 0 || InputV != 0)
        {
            deaccelerationSpeed = 0.6f;
        }
        else
        {
            deaccelerationSpeed = 0.1f;
        }

    }


    void Run()
    {
        if (stamina > 0 && currentState == PlayerState.Walking)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentState = PlayerState.Running;
            }
            else
            {
                currentState = PlayerState.Walking;
            }

        }
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded && currentState != PlayerState.Crouching)
        {

            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);


        }
    }


    void Crouching()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentState = PlayerState.Crouching;

        }
        else
        {
            currentState = PlayerState.Walking;
        }
    }



    void GroundDetect()
    {
        rGround = new Ray(Player.position, Player.up * -1.5f);
        Debug.DrawRay(rGround.origin, rGround.direction * 1f, Color.blue);
        LayerMask mask = LayerMask.GetMask("Ground");
        if (Physics.Raycast(rGround, out gHit, 1f, mask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;

        }
        groundeD();
    }

    private bool groundeD()
    {
        if (grounded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
