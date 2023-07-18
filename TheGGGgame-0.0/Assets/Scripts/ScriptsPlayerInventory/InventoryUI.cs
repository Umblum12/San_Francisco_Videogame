using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform slotsParent1;   // Transform del objeto padre de los slots del inventario 1
    public Transform slotsParent2;   // Transform del objeto padre de los slots del inventario 2
    public GameObject UiInventario2;
    private bool Inventario2Activado = false;
    public GameObject slotPrefab;   // Prefab del slot del inventario 1
    public GameObject slotPrefab2;   // Prefab del slot del inventario 2

    public List<GameObject> slots = new List<GameObject>();   // Lista de slots creados

    // Llama a InitializeInventoryUI en el inicio del juego
    private void Start()
    {
        InitializeInventoryUI();
        UiInventario2.SetActive(Inventario2Activado); // Desactiva el inventario por defecto al iniciar el juego
    }

    // Método para inicializar los slots del inventario
    public void InitializeInventoryUI()
    {
        // Elimina todos los slots anteriores
        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();

        // Crea los primeros 9 slots del inventario
        for (int i = 0; i < 9; i++)
        {
            // Instancia el prefab del slot
            GameObject slot = Instantiate(slotPrefab, slotsParent1);

            // Configura la imagen y el texto del slot con los detalles del elemento si corresponde
            if (i < inventory.items.Count)
            {
                Item item = inventory.items[i];
                Image image = slot.GetComponentInChildren<Image>();
                Text nameText = slot.GetComponentInChildren<Text>();

                image.sprite = item.itemIcon;
                nameText.text = item.itemName;
            }

            // Agrega el slot a la lista de slots
            slots.Add(slot);
        }

        // Crea los restantes 36 slots del inventario
        for (int i = 0; i < inventory.inventorySize; i++)
        {
            // Instancia el prefab del slot
            GameObject slot = Instantiate(slotPrefab2, slotsParent2);

            // Configura la imagen y el texto del slot con los detalles del elemento si corresponde
            if (i < inventory.items.Count)
            {
                Item item = inventory.items[i];
                Image image = slot.GetComponentInChildren<Image>();
                Text nameText = slot.GetComponentInChildren<Text>();

                image.sprite = item.itemIcon;
                nameText.text = item.itemName;
            }

            // Agrega el slot a la lista de slots
            slots.Add(slot);
        }

    }

    // Método para actualizar los slots del inventario
    public void UpdateInventoryUI()
    {
        // Actualiza los slots existentes con los elementos actuales del inventario
        for (int i = 0; i < inventory.items.Count; i++)
        {
            Item item = inventory.items[i];
            Image image = slots[i].GetComponentInChildren<Image>();
            Text nameText = slots[i].GetComponentInChildren<Text>();

            // Actualiza la imagen y el nombre del elemento en el slot
            image.sprite = item.itemIcon;
            nameText.text = item.itemName;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("e"))
        {
            Inventario2Activado = !Inventario2Activado; // Cambia el estado del inventario1 al pulsar la tecla "e"
            UiInventario2.SetActive(Inventario2Activado); // Activa o desactiva el inventario1 según el estado actual
        }
    }
}
