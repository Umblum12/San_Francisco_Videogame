using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    public CharacterController fcontroller;
    public float walkSpeed = 12f;
    public float runSpeed = 18f;
    public float gravity = 10f;
    public float jumpHeight = 3f;
    public float jumpHeightBackwards = 1f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float currentSpeed;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    // Referencia al script de PlayerStats
    private PlayerStats playerStats;

    public Animator anim;
    public PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        // Obtener la referencia al componente PlayerStats en el mismo objeto o en otro objeto
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        anim.SetBool("IsGrounded", isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;

        // Verificar si el jugador está corriendo (presionando la tecla de correr) y si tiene suficiente energía
        if (playerInput.PlayerMain.Run.ReadValue<float>() > 0 && playerStats.currentEnergy > 0)
        {
            // Consumir energía mientras se corre
            playerStats.ConsumeEnergy(1);
            currentSpeed = runSpeed;
            anim.SetFloat("PlayerWalkVelocity", move.magnitude * runSpeed);
        }
        else
        {
            currentSpeed = walkSpeed;
        }


        fcontroller.Move(move * currentSpeed * Time.deltaTime);

        if (playerInput.PlayerMain.Jump.triggered && isGrounded)
        {
            if (movementInput.y < 0) // Comprueba si el jugador está moviéndose hacia atrás
            {
                velocity.y = Mathf.Sqrt(jumpHeightBackwards * -2F * gravity); // Salto hacia atrás con una altura reducida
                anim.SetTrigger("PlayerJump");

            }
            else
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2F * gravity); // Salto normal hacia adelante
                anim.SetTrigger("PlayerJump");

            }
        }

        velocity.y += gravity * Time.deltaTime;

        fcontroller.Move(velocity * Time.deltaTime);
    }
}
