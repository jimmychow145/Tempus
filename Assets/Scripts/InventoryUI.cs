using UnityEngine;
using UnityEngine.UI;

/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour
{
	#region Singleton

	public static InventoryUI instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			Destroy(gameObject);
			return;
		}

		instance = this;
	}

	#endregion
	public Transform itemsParent;   // The parent object of all the items
	public GameObject inventoryUI;  // The entire UI

	public Inventory inventory;    // Our current inventory

	InventorySlot[] slots;  // List of all the slots

	void Start()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback

		// Populate our slots array
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	void Update()
	{
		// Check to see if we should open/close the inventory
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
			Inventory.instance.DestroyItemInfo();
		}
	}

	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	void UpdateUI()
	{
		// Loop through all the slots
		for (int i = 0; i < slots.Length; i++)
		{
			
			if (i < inventory.items.Count)  // If there is an item to add
			{
				slots[i].AddItem(inventory.items[i]);   // Add it
				slots[i].itemAmount.enabled = true;
				slots[i].itemAmount.text = slots[i].item.itemAmount.ToString("n0");
				Debug.Log("added");
			}
			else
			{
				// Otherwise clear the slot
				slots[i].ClearSlot();
			}
		}
	}
}