using UnityEngine;

[CreateAssetMenu(fileName = "Honey", menuName = "Items/Resources/Honey")]

public class Honey : Item
{
    void Start()
    {

    }
    public override void Use()
    {
        Debug.Log("You have used this item for 5 hunger points");
        Inventory.instance.characterStat.AddHunger(5);

        itemAmount--;
        Inventory.instance.onItemChangedCallback.Invoke();
        if (itemAmount <= 0)
        {
            RemoveFromInventory();
            Inventory.instance.DestroyItemInfo();

        }
    }
}
