using UnityEngine;

public class InteractableItem : MonoBehaviour
{ 
    public Item item;

    public void Interact()
    {
        Inventory.instance.AddItem(item);
        Destroy(gameObject);
    }
}
