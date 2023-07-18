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
    Vector3 amount = Vector3.zero;

    public Vector3 addPos = new Vector3(0, 1.63f, 0);

    Quaternion q = Quaternion.identity;

    private void Update()
    {
        if (rotationActive)
        {
            mouseDelta.Set(Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y"),
            Input.GetAxisRaw("Mouse ScrollWheel"));

            amount += -mouseDelta * sensitivity;
            amount.z = Mathf.Clamp(amount.z, 50, 100);
            amount.y = Mathf.Clamp(amount.y, -50, 50);

            q = Quaternion.AngleAxis(-amount.x, Vector3.up) *
        Quaternion.AngleAxis(amount.y, Vector3.right);

            Vector3 dirPos = q * Vector3.forward;
            dirPos *= amount.z * 0.1f;

            // Realizar el raycast desde la posici�n del objetivo hasta la posici�n de la c�mara
            RaycastHit hit;
            if (Physics.Linecast(target.position, target.position - dirPos, out hit))
            {
                // Ajustar la posici�n de la c�mara para evitar la colisi�n
                transform.position = hit.point;
            }
            else
            {
                // Si no hay colisi�n, mover la c�mara normalmente
                transform.position = target.position - dirPos;
            }

            transform.LookAt(target.transform.position + addPos);
        }

        if (lookAtPlayer || rotationActive)
        {
            transform.LookAt(target);
        }

        if (Input.GetButton("Fire1"))
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
