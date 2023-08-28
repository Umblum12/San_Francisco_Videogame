using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    private float sensitivity = 10.0f;
    public bool lookAtPlayer = false;
    public bool rotationActive;
    Vector3 mouseDelta = Vector3.zero;
    Vector2 scrollDelta = Vector2.zero; // Nuevo Vector2 para el scroll
    Vector3 amount = Vector3.zero;

    public Vector3 addPos = new Vector3(0, 1.63f, 0);

    Quaternion q = Quaternion.identity;

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

    private void Update()
    {
        if (rotationActive)
        {
            mouseDelta.Set(playerInput.PlayerMain.LookCam.ReadValue<Vector2>().x * 0.01f,
                           -playerInput.PlayerMain.LookCam.ReadValue<Vector2>().y * 0.01f,
                           0);

            scrollDelta = playerInput.PlayerMain.Scroll.ReadValue<Vector2>();

            amount += new Vector3(-mouseDelta.x, mouseDelta.y, scrollDelta.y) * sensitivity;
            amount.z = Mathf.Clamp(amount.z, 50, 100);
            amount.y = Mathf.Clamp(amount.y, -50, 50);

            q = Quaternion.AngleAxis(amount.x, Vector3.up) *
                Quaternion.AngleAxis(-amount.y, Vector3.right); // Invertimos el valor del eje Y aquí

            Vector3 dirPos = q * Vector3.forward;
            dirPos *= amount.z * 0.1f;

            RaycastHit hit;
            if (Physics.Linecast(target.position, target.position - dirPos, out hit))
            {
                transform.position = hit.point;
            }
            else
            {
                transform.position = target.position - dirPos;
            }

            transform.LookAt(target.transform.position + addPos);
        }

        if (lookAtPlayer || rotationActive)
        {
            transform.LookAt(target);
        }

        if (playerInput.PlayerMain.LoockCam.ReadValue<float>() > 0)
        {
            rotationActive = true;
        }
        else
        {
            rotationActive = false;
            transform.LookAt(target);
        }
    }
}