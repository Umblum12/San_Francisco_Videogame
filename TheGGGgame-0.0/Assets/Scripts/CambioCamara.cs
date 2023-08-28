using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public FPSController FPS;
    public TPSController TPS;
    public TPSCharacterController TPSCC;
    public FPSCharacterController FPSCC;
    public Transform pos1era, pos3era;
    public Transform padre1, padre2, padre3;
    bool Vista;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.ChangePerspective.PerspectiveFirstPerson.triggered)
        {
            Vista = true; // Asigna "P" al scroll hacia arriba del mouse
        }

        if (playerInput.ChangePerspective.PerspectiveThirdPerson.triggered)
        {
            Vista = false; // Asigna "T" al scroll hacia abajo del mouse
        }
        if (Vista == true)
        {
        padre2.SetParent(padre1);
        transform.position = Vector3.Lerp(transform.position, pos1era.position, 5 * Time.deltaTime);
        FPS.enabled = true;
        FPSCC.enabled = true;
        TPS.enabled = false;
        TPSCC.enabled = false;
        }
        else
        {
        padre2.SetParent(padre3);
        transform.position = Vector3.Lerp(transform.position, pos3era.position, 5 * Time.deltaTime);
        FPS.enabled = false;
        FPSCC.enabled = false;
        TPS.enabled = true;
        TPSCC.enabled = true;
        }
    }
}
