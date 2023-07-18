using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_de_preuba : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask campaDelJugador;
    bool estarAlerta;
    public Transform Jugador;
    public float Velocidad;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.Find("Player");

        if (playerObj != null)
        {
            Jugador = playerObj.transform;
            Debug.Log("¡Se encontró el objeto 'Player' en la escena y se obtuvo su Transform!");
        }
        else
        {
            Debug.Log("El objeto 'Player' no se encontró en la escena.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, campaDelJugador);

        if (estarAlerta == true)
        {
            Vector3 posisionJugador = new Vector3(Jugador.position.x, transform.position.y,Jugador.position.z);
            transform.LookAt(posisionJugador);
            transform.position = Vector3.MoveTowards(transform.position, posisionJugador, Velocidad * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,rangoDeAlerta);
    }
}
