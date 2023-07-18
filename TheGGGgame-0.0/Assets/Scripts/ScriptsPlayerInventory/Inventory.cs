using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int inventorySize = 36; // Tamaño del inventario
    public List<Item> items = new List<Item>();    // Lista de objetos en el inventario

    public InventoryUI inventoryUI;

    // Método para agregar un objeto al inventario
    public void AddItem(Item item)
    {
        // Verificar si el inventario está lleno
        if (items.Count >= inventorySize)
        {
            Debug.Log("Inventario lleno. No se puede agregar el objeto.");
            return;
        }

        // Agregar el objeto al inventario
        items.Add(item);

        // Actualizar la interfaz de usuario
        inventoryUI.UpdateInventoryUI();

        Debug.Log("Objeto agregado al inventario: " + item.itemName);
    }

    // Método para eliminar un objeto del inventario
    public void RemoveItem(Item item)
    {
        // Verificar si el objeto está en el inventario
        if (items.Contains(item))
        {
            // Eliminar el objeto del inventario
            items.Remove(item);

            // Actualizar la interfaz de usuario
            inventoryUI.UpdateInventoryUI();

            Debug.Log("Objeto eliminado del inventario: " + item.itemName);
        }
        else
        {
            Debug.Log("El objeto no está en el inventario.");
        }
    }
}
