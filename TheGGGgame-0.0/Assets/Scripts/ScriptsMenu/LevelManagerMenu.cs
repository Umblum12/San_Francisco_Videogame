using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerMenu : MonoBehaviour
{
    public string gameSceneName = "GameScene"; // Nombre de la escena del juego
    public GameObject menuprincipalrPanel; // Referencia al panel de multiplayer
    public GameObject multiplayerPanel; // Referencia al panel de multiplayer
    public GameObject configuracionPanel; // Referencia al panel de Configuracion
    public GameObject configuracionaudioPanel; // Referencia al panel de ConfiguracionAudio
    public GameObject configuraciongraficosPanel; // Referencia al panel de ConfiguracionGraficos

    public GameObject gamePrefabToInstantiate; // Referencia al prefab que deseas instanciar en la GameScene
    public GameObject FpsInstanciate; // Referencia al prefab que deseas instanciar en la GameScene
    public GameObject canvas; // Referencia al prefab que deseas instanciar en la GameScene
    public GameObject fpsObject; // Referencia al prefab que deseas instanciar

    private void Awake()
    {
        // Mantener este objeto vivo entre escenas
        DontDestroyOnLoad(gameObject);
    }
    public void start()
    {
        // Instancia el objeto dentro del objeto "Canvas"
        Instantiate(FpsInstanciate);
    }
    public void Update()
    {
        // Busca el objeto con el nombre "Fps" en la escena
        fpsObject = GameObject.Find("Fps");
        // Verifica si se encontró el objeto "Fps"
        if (fpsObject != null)
        {
            // Calcula los FPS promediando el tiempo que toma un frame
            float fps = 1.0f / Time.deltaTime;
            // Encuentra el componente Text en el objeto instanciado
            Text fpsTextComponent = fpsObject.GetComponent<Text>();

            // Actualiza el valor del texto con el valor de los FPS
            if (fpsTextComponent != null)
            {
                fpsTextComponent.text = "FPS: " + Mathf.RoundToInt(fps).ToString();
            }
        }
    }
    public void StartGame()
    {
        // Desactivar los paneles y cargar la escena del juego
        multiplayerPanel.SetActive(false);
        configuracionPanel.SetActive(false);
        configuracionaudioPanel.SetActive(false);
        configuraciongraficosPanel.SetActive(false);

        // Cargar la escena del juego al hacer clic en el botón "Iniciar"
        SceneManager.LoadScene(gameSceneName);
    }
    // Se llama cuando se carga una nueva escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si la escena cargada es la GameScene, instancia el prefab
        if (scene.name == gameSceneName && gamePrefabToInstantiate != null)
        {
            // Busca el objeto con la etiqueta "Canvas" en la escena
            canvas = GameObject.Find("Canvas");
            // Verifica si se encontró el objeto con la etiqueta "Canvas"
            if (canvas != null)
            {
                // Instancia el objeto dentro del objeto "Canvas"
                InstantiateWithoutCloneMethod(FpsInstanciate);
            }

            GameObject prefabInstance1 = Instantiate(gamePrefabToInstantiate);
            GameObject prefabInstance2 = Instantiate(gamePrefabToInstantiate);
            GameObject prefabInstance3 = Instantiate(gamePrefabToInstantiate);

            // Modificar rotación y posición de las instancias
            prefabInstance1.transform.position = new Vector3(462f, 205.6f, 407f); // Cambia las coordenadas como desees
            prefabInstance1.transform.rotation = Quaternion.Euler(88.304f, 77.545f, 102.649f); // Cambia los valores de rotación como desees

            prefabInstance2.transform.position = new Vector3(1344f, 205.6f, 407f); // Cambia las coordenadas como desees
            prefabInstance2.transform.rotation = Quaternion.Euler(158.264f, 88.414f, 179.413f); // Cambia los valores de rotación como desees

            prefabInstance3.transform.position = new Vector3(-352f, 205.6f, 407f); // Cambia las coordenadas como desees
            prefabInstance3.transform.rotation = Quaternion.Euler(22.144f, 90f, 0f); // Cambia los valores de rotación como desees
        }
    }
    private GameObject InstantiateWithoutCloneMethod(GameObject original)
    {
        GameObject instance = Instantiate(original, canvas.transform);
        instance.name = original.name; // Cambia el nombre del objeto instanciado
        return instance;
    }
    private void OnEnable()
    {
        // Suscribir el método OnSceneLoaded al evento SceneManager.sceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        // Desuscribir el método OnSceneLoaded del evento SceneManager.sceneLoaded
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void OpenMultiplayerPanel()
    {
        // Desactivar los paneles y cargar la el panel Multiplayer
        menuprincipalrPanel.SetActive(false);
        configuracionPanel.SetActive(false);
        configuracionaudioPanel.SetActive(false);
        configuraciongraficosPanel.SetActive(false);

        // Activar el panel de multiplayer al hacer clic en el botón "Multiplayer"
        multiplayerPanel.SetActive(true);
    }
    public void CloseMultiplayerPanel()
    {
        // Desactivar el panel de multiplayer
        multiplayerPanel.SetActive(false);
        // Activar el panel de MenuPrincipal al hacer clic en el botón "MenuPrincipal"
        menuprincipalrPanel.SetActive(true);
    }
    public void OpenConfiguracionPanel()
    {
        // Desactivar los paneles y cargar la el panel Configuracion
        menuprincipalrPanel.SetActive(false);
        multiplayerPanel.SetActive(false);
        configuracionaudioPanel.SetActive(false);
        configuraciongraficosPanel.SetActive(false);

        // Activar el panel de Configuracion al hacer clic en el botón "Configuracion"
        configuracionPanel.SetActive(true);
    }
    public void CloseConfiguracionPanel()
    {
        // Desactivar el panel de Configuracion
        configuracionPanel.SetActive(false);
        // Activar el panel de MenuPrincipal al hacer clic en el botón "MenuPrincipal"
        menuprincipalrPanel.SetActive(true);
    }
    public void OpenConfiguracionAudioPanel()
    {
        // Desactivar los paneles y cargar la el panel ConfiguracionAudio
        menuprincipalrPanel.SetActive(false);
        multiplayerPanel.SetActive(false);
        configuracionPanel.SetActive(false);
        configuraciongraficosPanel.SetActive(false);

        // Activar el panel de ConfiguracionAudio al hacer clic en el botón "ConfiguracionAudio"
        configuracionaudioPanel.SetActive(true);
    }
    public void CloseConfiguracionAudioPanel()
    {
        // Desactivar el panel de ConfiguracionAudio
        configuracionaudioPanel.SetActive(false);
        // Activar el panel de Configuracion al hacer clic en el botón "Configuracion"
        configuracionPanel.SetActive(true);
    }
    public void OpenConfiguracionGraficosPanel()
    {
        // Desactivar los paneles y cargar la el panel ConfiguracionGraficos
        menuprincipalrPanel.SetActive(false);
        multiplayerPanel.SetActive(false);
        configuracionPanel.SetActive(false);
        configuracionaudioPanel.SetActive(false);

        // Activar el panel de ConfiguracionGraficos al hacer clic en el botón "ConfiguracionGraficos"
        configuraciongraficosPanel.SetActive(true);
    }
    public void CloseConfiguracionGraficosPanel()
    {
        // Desactivar el panel de ConfiguracionGraficos
        configuraciongraficosPanel.SetActive(false);
        // Activar el panel de Configuracion al hacer clic en el botón "Configuracion"
        configuracionPanel.SetActive(true);
    }
    public void QuitGame()
    {
        // Salir del juego (solo funciona en el modo de ejecución)
        Application.Quit();
    }
}