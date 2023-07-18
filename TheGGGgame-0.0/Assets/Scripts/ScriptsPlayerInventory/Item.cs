using UnityEngine;

public enum ItemType
{
    Weapon,
    Consumable,
    Armor,
    QuestItem
}

public class Item : MonoBehaviour
{
    public string itemName;
    public ItemType itemType;
    public int itemID;
    public Sprite itemIcon;

    // Aquí puedes agregar más propiedades y atributos para personalizar el ítem, como estadísticas, efectos, etc.

    // Método para usar el ítem
    public virtual void Use()
    {
        Debug.Log("Using item: " + itemName);
        // Implementa el comportamiento específico para usar el ítem según su tipo
        // Por ejemplo, si es un arma, puede disparar, si es un consumible, puede curar, etc.
    }
}
