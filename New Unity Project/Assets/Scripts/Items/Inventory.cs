using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<CreatedItem> items;
    [SerializeField]
    ItemSlot currentItemSlot;
    [SerializeField]
    GameObject windowChange;
    [SerializeField]
    Item item;
    //Really Bad Impementation, but I'm lazy
    [Header("Armor")]
    public ItemSlot chestplateSlot;

    private void Start()
    {
        foreach(CreatedItem item in items)
        {
            item.OnItemTake += Item_OnItemTake;
        }
    }

    private void Item_OnItemTake(object sender, ItemArgs e)
    {
        TakeItem(e.item);
    }

    public void TakeItem(Item e)
    {
        item = e;
        if (e.itemType == ItemType.Chestplate)
        {
            CheckForCurrentItem(chestplateSlot);
        }
    }

    void CheckForCurrentItem(ItemSlot currentSlot)
    {
        currentItemSlot = currentSlot;
        if (currentItemSlot.item == null)
        {
            currentItemSlot.UpdateItem(item);
        }
        else
        {
            windowChange.SetActive(true);
        }
    }
    
    public void UpdateItem(bool e)
    {
        if(e)
            currentItemSlot.UpdateItem(item);
        windowChange.SetActive(false);
    }
}
