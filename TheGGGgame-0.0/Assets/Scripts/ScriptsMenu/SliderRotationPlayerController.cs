using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRotationPlayerController : MonoBehaviour
{
    public Transform rotatingObject; // Objeto que deseas rotar
    public Slider rotationSlider; // Referencia al slider

    private void Update()
    {
        // Obtener el valor del slider y aplicar la rotación al objeto
        float rotationValue = rotationSlider.value;
        rotatingObject.rotation = Quaternion.Euler(0f, rotationValue, 0f);
    }
}
