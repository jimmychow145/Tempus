using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

	#region Singleton

	public static Inventory instance;

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

	// Callback which is triggered when
	// an item gets added/removed.
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 20;  // Amount of slots in inventory

	// Current list of items in inventory
	public List<Item> items = new List<Item>();
	public List<Item> hotbarItems = new List<Item>();
	public HotBarController hotBarController;

	public Transform canvas;
	public GameObject itemInfoPrefab;
	public GameObject currentItemInfo = null;

	public CharacterStat characterStat;

	public float moveX = 0f;
	public float moveY = 0f;
	
	void Start()
    {

	}
	public void SwitchHotbarInventory(Item item)
    {
		foreach(Item i in items)
        {
			if(i == item)
            {
				if(hotbarItems.Count >= hotBarController.HotBarSlotSize)
                {
					Debug.Log("No more slots avaliable in the hotbar");
                }
				else
                {
					hotbarItems.Add(item);
					items.Remove(item);
					onItemChangedCallback.Invoke();
				}

				return;
            }
        }

		foreach (Item i in hotbarItems)
        {
			if(i == item)
            {
				hotbarItems.Remove(item);
				items.Add(item);
				onItemChangedCallback.Invoke();
				return;
			}
        }

	}
	// Add a new item. If there is enough room we
	// return true. Else we return false.
	public bool Add(Item item)
	{
		Item copyItem = Instantiate(item);
		// Don't do anything if it's a default item
		if (!item.isDefaultItem)
		{
			// Check if out of space
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return false;
			}
			for (int i = 0; i < hotbarItems.Count; i++)
            {
				if(hotbarItems[i].name == item.name)
                {
					++hotbarItems[i].itemAmount;
					Debug.Log("same");
					onItemChangedCallback.Invoke();
					return true;
                }
            }
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].name == item.name)
				{
					++items[i].itemAmount;
					Debug.Log("same");
					onItemChangedCallback.Invoke();
					return true;
				}
			}
			items.Add(copyItem);    // Add item to list

			// Trigger callback
			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
		}

		return true;
	}

	// Remove an item
	public void Remove(Item item)
	{
		if(items.Contains(item))
        {
			items.Remove(item); // Remove item from list
		}
		else if (hotbarItems.Contains(item))
		{
			hotbarItems.Remove(item); // Remove item from list
		}


		// Trigger callback
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

	public void DisplayItemInfo(string itemName, string itemDescription, Vector2 buttonPos)
    {
		if(currentItemInfo != null)
        {
			Destroy(currentItemInfo.gameObject);
        }
		buttonPos.x += moveX;
		buttonPos.y += moveY;

		currentItemInfo = Instantiate(itemInfoPrefab, buttonPos, Quaternion.identity, canvas);
		currentItemInfo.GetComponent<ItemInfo>().SetUp(itemName, itemDescription);
			
    }

	public void DestroyItemInfo()
    {
		if(currentItemInfo != null)
        {
			Destroy(currentItemInfo.gameObject);
			Debug.Log("destroying");
		}
		Debug.Log("not destroying");
	}

}