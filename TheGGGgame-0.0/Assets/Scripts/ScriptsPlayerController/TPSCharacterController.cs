using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 6f;
    public float runSpeed = 10f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    private Vector3 velocity;
    private bool isRunning;
    private Camera mainCamera;

    public Animator anim;
    public PlayerInput playerInput;

    // Referencia al script de PlayerStats
    private PlayerStats playerStats;


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
        mainCamera = Camera.main;
        playerStats = GetComponent<PlayerStats>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        anim.SetBool("IsGrounded", isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 movement = GetCameraRelativeMovement(movementInput.y, movementInput.x);
 
        anim.SetFloat("PlayerWalkVelocity", movement.magnitude * walkSpeed);
        isRunning = playerInput.PlayerMain.Run.ReadValue<float>() > 0 && playerStats.currentEnergy > 0;

        float speed = isRunning ? runSpeed : walkSpeed;

        if (isGrounded)
        {
            if (playerInput.PlayerMain.Jump.triggered)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                anim.SetTrigger("PlayerJump");
                isRunning = false; // Desactivar la carrera al saltar
            }

            if (isRunning)
            {
                playerStats.ConsumeEnergy(1);
                anim.SetFloat("PlayerWalkVelocity", movement.magnitude * runSpeed);
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        controller.Move(movement * speed * Time.deltaTime);

        if (movement.magnitude > 0.1f)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.15f);
        }
    }

    private Vector3 GetCameraRelativeMovement(float movementInputY, float movementInputX)
    {
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        return cameraForward * movementInputY + cameraRight * movementInputX;
    }

}