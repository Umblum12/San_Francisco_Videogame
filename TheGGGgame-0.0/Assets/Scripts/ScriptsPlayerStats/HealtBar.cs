using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider healtSlider; // Referencia al componente Slider
    public PlayerStats playerStats; // Referencia al script PlayerStats

    private void Start()
    {
        // Obtener la referencia al componente Slider en el mismo objeto o en otro objeto
        healtSlider = GetComponent<Slider>();

        // Obtener la referencia al script PlayerStats en el mismo objeto o en otro objeto
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        // Actualizar el valor del Slider según el estado actual de la energía en PlayerStats
        healtSlider.value = playerStats.currentHealth;
    }
}
