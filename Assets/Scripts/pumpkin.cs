using UnityEngine;

[CreateAssetMenu(fileName = "Pumpkin", menuName = "Items/Resources/Pumpkin")]

public class pumpkin : Item
{
    public Item item;
    void Start()
    {

    }
    public override void Use()
    {
        Debug.Log("You have used this item for 5 coins");
        for(int i = 0; i < 5; i++)
        {
            Inventory.instance.Add(item);
        }

        itemAmount--;
        Inventory.instance.onItemChangedCallback.Invoke();
        if (itemAmount <= 0)
        {
            RemoveFromInventory();
            Inventory.instance.DestroyItemInfo();

        }
    }
}
