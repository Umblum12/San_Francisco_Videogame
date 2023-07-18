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

    // Aqu� puedes agregar m�s propiedades y atributos para personalizar el �tem, como estad�sticas, efectos, etc.

    // M�todo para usar el �tem
    public virtual void Use()
    {
        Debug.Log("Using item: " + itemName);
        // Implementa el comportamiento espec�fico para usar el �tem seg�n su tipo
        // Por ejemplo, si es un arma, puede disparar, si es un consumible, puede curar, etc.
    }
}
