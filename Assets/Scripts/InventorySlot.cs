using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour
{

	public Image icon;          // Reference to the Icon image
	public Button removeButton; // Reference to the remove button
	public Text itemAmount;

	public Item item;  // Current item in the slot

	// Add item to the slot
	void Start()
    {
		itemAmount.enabled = false;
    }
	public void AddItem(Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		itemAmount.text = item.itemAmount.ToString();
		itemAmount.enabled = true;
		if(transform.parent.gameObject.CompareTag("Hotbar"))
        {
			removeButton.interactable = false;
			return;
		}

		removeButton.interactable = true;
	}

	// Clear the slot
	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
		itemAmount.text = "0";
		itemAmount.enabled = false;
	}

	// Called when the remove button is pressed
	public void OnRemoveButton()
	{
		Inventory.instance.Remove(item);
	}

	// Called when the item is pressed
	public void UseItem()
	{
		if (Input.GetKey(KeyCode.LeftAlt))
		{
			Debug.Log("Trying to switch");
			Inventory.instance.SwitchHotbarInventory(item);
			Inventory.instance.DestroyItemInfo();

		}
		else if (item != null)
		{
			item.Use();
			Debug.Log("used item");
		}

		
		else
        {
			
		}

		
	}

	public void OnCursorEnter()
    {
		if(item == null)
        {
			return;
        }
		Inventory.instance.DisplayItemInfo(item.name, item.GetItemDescription(), transform.position);

		


	}

	public void OnCursorExit()
    {
		if (item == null)
		{
			return;
		}
		Inventory.instance.DestroyItemInfo();

	}

}