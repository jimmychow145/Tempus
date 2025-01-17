using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

	new public string name = "New Item";    // Name of the item
	public Sprite icon = null;              // Item icon
	public bool isDefaultItem = false;      // Is the item default wear?
	public int itemAmount = 1;
	public string itemDescription = "Used for food";

	// Called when the item is pressed in the inventory
	public virtual void Use()
	{
		// Use the item
		// Something might happen

		Debug.Log("Using " + name);
	}

	public virtual string GetItemDescription()
    {
		return itemDescription;
    }

	public void RemoveFromInventory()
	{
		Inventory.instance.Remove(this);
	}

}