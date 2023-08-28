using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMinimap : MonoBehaviour
{
    //camara
    public GameObject cameraMinimapa;
    public float distanciaY;

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
        if (playerInput.PlayerMain.ZoomInCameraMinimap.triggered && distanciaY <= 19)
        {
            distanciaY++;
            cameraMinimapa.transform.position = new Vector3(transform.position.x, distanciaY, transform.position.z);
        }
        if (playerInput.PlayerMain.ZoomOutCameraMinimap.triggered && distanciaY >= 5)
        {
            distanciaY--;
            cameraMinimapa.transform.position = new Vector3(transform.position.x, distanciaY, transform.position.z);
        }
    }
}
