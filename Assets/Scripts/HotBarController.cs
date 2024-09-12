using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarController : MonoBehaviour
{


    public int HotBarSlotSize;
    public List<InventorySlot> hotbarSlots = new List<InventorySlot>();
    public GameObject Hotbar;

    KeyCode[] hotbarKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5 };
    // Start is called before the first frame update
    void Start()
    {
        Hotbar = GameObject.Find("Hotbar");
        HotBarSlotSize = Hotbar.transform.childCount;
        SetUpHotbarSlots();
        Inventory.instance.onItemChangedCallback += UpdateHotbarUI;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < hotbarKeys.Length; i++)
        {
            if(Input.GetKeyDown(hotbarKeys[i]))
            {
                hotbarSlots[i].UseItem();
                //use item
                return;
                
            }
        }
    }
    void UpdateHotbarUI()
    {
        int currentUsedSlotCount = Inventory.instance.hotbarItems.Count;
        for(int i = 0; i < HotBarSlotSize; i++)
        {
            if(i < currentUsedSlotCount)
            {
                hotbarSlots[i].AddItem(Inventory.instance.hotbarItems[i]);
            }
            else
            {
                hotbarSlots[i].ClearSlot();
            }
        }
    }
    void SetUpHotbarSlots()
    {
        for(int i = 0; i < HotBarSlotSize; i++)
        {
            InventorySlot slot = Hotbar.transform.GetChild(i).GetComponent<InventorySlot>();
            hotbarSlots.Add(slot);
        }
    }
}
