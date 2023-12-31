using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    //camara
    private new Transform camera;
    //Esta variable sirve para la sencibilidad que tendra el raton sobre la camara
    public Vector2 Sensibility;
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
        //Esta variable sirve para encontrar la camara
        camera = transform.Find("MainCamera");
        //esta linea de codigo sirve para bloquear el cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Esta variable sirve para poder mover la camara en Horizontal el eje x
        float MovHor = playerInput.PlayerMain.LookCam.ReadValue<Vector2>().x * 0.01f;
        //Esta variable sirve para poder mover la camara en Vertical el eje y
        float MovVer = playerInput.PlayerMain.LookCam.ReadValue<Vector2>().y * 0.01f;
        //Este if sirve para rotar la camara en el angulo y
        if (MovHor != 0)
        {
            transform.Rotate(Vector3.up * MovHor * Sensibility.x);
        }
        //Este if sirve para rotar la camara en el angulo x
        if (MovVer != 0)
        {
            float angle = (camera.localEulerAngles.x - MovVer * Sensibility.y + 360) % 360;
            if (angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -80, 80);
            camera.localEulerAngles = Vector3.right * angle;
        }
    }
}