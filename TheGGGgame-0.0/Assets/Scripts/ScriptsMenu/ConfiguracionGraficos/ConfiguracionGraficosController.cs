using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfiguracionGraficosController : MonoBehaviour
{
    public Text fpsText; // Asigna el Text en el Inspector
    public Toggle fpsToggle; // Asigna el Toggle en el Inspector
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula los FPS promediando el tiempo que toma un frame
        float fps = 1.0f / Time.deltaTime;

        // Actualiza el Text con el valor de FPS si el Toggle está activado
        if (fpsToggle.isOn)
        {
            fpsText.gameObject.SetActive(true);
            fpsText.text = "FPS: " + Mathf.RoundToInt(fps).ToString();
        }
        else
        {
            fpsText.gameObject.SetActive(false);
        }
    }
}
