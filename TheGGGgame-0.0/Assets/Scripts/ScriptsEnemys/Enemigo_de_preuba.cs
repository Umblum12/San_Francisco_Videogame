using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_de_preuba : MonoBehaviour
{
    public float rangoDeAlerta;
    public float rangoDeEscape;
    public LayerMask campaDelJugador;
    bool estarAlerta;
    public Transform Jugador;
    public float Velocidad;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        GameObject playerObj = GameObject.Find("Player");

        if (playerObj != null)
        {
            Jugador = playerObj.transform;
        }
    }
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, campaDelJugador);

        if (estarAlerta == true)
        {
            Vector3 posisionJugador = new Vector3(Jugador.position.x, transform.position.y, Jugador.position.z);
            transform.LookAt(posisionJugador);
            Vector3 movement = transform.position = Vector3.MoveTowards(transform.position, posisionJugador, Velocidad * Time.deltaTime);
            anim.SetFloat("PlayerWalkVelocity", movement.magnitude * Velocidad);
        }
        else
        {
            // Restablecer la velocidad de la animación a 0 cuando no esté alerta
            anim.SetFloat("PlayerWalkVelocity", 0f);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}
