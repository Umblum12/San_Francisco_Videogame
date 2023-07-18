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

    // Referencia al script de PlayerStats
    private PlayerStats playerStats;

    private void Start()
    {
        mainCamera = Camera.main;
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = GetCameraRelativeMovement(horizontalInput, verticalInput);

        isRunning = Input.GetKey(KeyCode.LeftShift) && playerStats.currentEnergy > 0;

        float speed = isRunning ? runSpeed : walkSpeed;

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                isRunning = false; // Desactivar la carrera al saltar
            }

            if (isRunning)
            {
                playerStats.ConsumeEnergy(1);
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

    private Vector3 GetCameraRelativeMovement(float horizontalInput, float verticalInput)
    {
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        return cameraForward * verticalInput + cameraRight * horizontalInput;
    }
}