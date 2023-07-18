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

    private void Start()
    {
        // Obtener la referencia al componente PlayerStats en el mismo objeto o en otro objeto
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;

        // Verificar si el jugador está corriendo (presionando la tecla de correr) y si tiene suficiente energía
        if (Input.GetKey(KeyCode.LeftShift) && playerStats.currentEnergy > 0)
        {
            // Consumir energía mientras se corre
            playerStats.ConsumeEnergy(1);
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }


        fcontroller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (Input.GetAxis("Vertical") < 0) // Comprueba si el jugador está moviéndose hacia atrás
            {
                velocity.y = Mathf.Sqrt(jumpHeightBackwards * -2F * gravity); // Salto hacia atrás con una altura reducida
            }
            else
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2F * gravity); // Salto normal hacia adelante
            }
        }

        velocity.y += gravity * Time.deltaTime;

        fcontroller.Move(velocity * Time.deltaTime);
    }
}
