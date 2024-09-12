using UnityEngine;

[CreateAssetMenu(fileName = "Wood", menuName = "Items/Resources/Wood")]

public class wood : Item
{
    
    void Start()
    {
        
    }
    public override void Use()
    {
        Debug.Log("You have sold this for 5 coins");
        itemAmount--;
        Inventory.instance.onItemChangedCallback.Invoke();
        if (itemAmount <= 0)
        {
            RemoveFromInventory();
            Inventory.instance.DestroyItemInfo();

        }
    }
}
