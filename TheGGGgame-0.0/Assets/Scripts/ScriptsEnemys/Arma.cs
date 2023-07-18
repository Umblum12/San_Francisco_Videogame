using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public int Damagedelarma = 5;
    // Referencia al script de PlayerStats
    public PlayerStats playerStats;

    void Start()
    {
        GameObject playerObj = GameObject.Find("Player");

        if (playerObj != null)
        {
            playerStats = playerObj.GetComponent<PlayerStats>();
            Debug.Log("¡Se encontró el objeto 'Player' en la escena y se obtuvo su Transform!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.TakeDamage(Damagedelarma);
        }
    }
}
