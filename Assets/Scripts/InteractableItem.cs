using UnityEngine;

public class InteractableItem : MonoBehaviour
{ 
    public void Interact(Inventory playerInventory)
    {
        string itemName = gameObject.name;
        
        playerInventory.AddItem(itemName);

        Destroy(gameObject);
    }
    
}
