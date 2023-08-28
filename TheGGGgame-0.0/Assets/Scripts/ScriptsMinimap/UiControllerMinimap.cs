using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControllerMinimap : MonoBehaviour
{
    public GameObject UiMinimapa;
    public float distanciaUiY;
    private bool minimapaActivado = true;

    public PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    public void AcercarUiMinimap()
    {
        if (distanciaUiY < 3)
        {
            distanciaUiY++;
            UiMinimapa.transform.localScale = new Vector3(distanciaUiY, distanciaUiY, distanciaUiY);
        }
    }

    public void AlejarUiMinimap()
    {
        if (distanciaUiY > 1)
        {
            distanciaUiY--;
            UiMinimapa.transform.localScale = new Vector3(distanciaUiY, distanciaUiY, distanciaUiY);
        }
    }

    public void CerrarUiMinimap()
    {
        UiMinimapa.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        UiMinimapa.SetActive(minimapaActivado); // Activa el minimapa por defecto al iniciar el juego
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.Minimap.OpenCloseMinimap.triggered)
        {
            minimapaActivado = !minimapaActivado; // Cambia el estado del minimapa al pulsar la tecla "m"
            UiMinimapa.SetActive(minimapaActivado); // Activa o desactiva el minimapa según el estado actual
        }
    }
}
