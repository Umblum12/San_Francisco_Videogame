using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public Item item; // Referencia al item que representa este objeto recolectable
    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventory != null)
            {
                inventory.AddItem(item);
                Destroy(gameObject); // O desactivar el objeto recolectable en lugar de destruirlo
            }
        }
    }
}