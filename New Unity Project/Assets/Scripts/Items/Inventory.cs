using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField]
    ItemSlot helmetSlot;
    [SerializeField]
    ItemSlot chestplateSlot;
    [SerializeField]
    ItemSlot leggingsSlot;
    [SerializeField]
    ItemSlot bootsSlot;
    [SerializeField]
    ItemSlot beltSlot;
    [SerializeField]
    ItemSlot ringSlot;
    [SerializeField]
    ItemSlot neckSlot; 

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
        switch (e.itemType)
        {
            case ItemType.Helmet:
                CheckForCurrentItem(helmetSlot);
                break;
            case ItemType.Chestplate:
                CheckForCurrentItem(chestplateSlot);
                break;
            case ItemType.Leggings:
                CheckForCurrentItem(leggingsSlot);
                break;
            case ItemType.Boots:
                CheckForCurrentItem(bootsSlot);
                break;
            case ItemType.Ring:
                CheckForCurrentItem(ringSlot);
                break;
            case ItemType.Neck:
                CheckForCurrentItem(neckSlot);
                break;
            case ItemType.Belt:
                CheckForCurrentItem(beltSlot);
                break;
            default:
                break;
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
            WindowChangeEnable();
        }
    }

    void WindowChangeEnable()
    {
        windowChange.SetActive(true);
        windowChange.transform.GetChild(0).GetComponent<TMP_Text>().text =
            "Do you want to replace your " + currentItemSlot.item.name + " with " + item.name + " ?";
    }

    public void UpdateItem(bool e)
    {
        if(e)
            currentItemSlot.UpdateItem(item);
        windowChange.SetActive(false);
    }
}
