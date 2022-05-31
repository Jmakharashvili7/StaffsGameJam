using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryWindow;
    [SerializeField]
    List<CreatedItem> items;
    [SerializeField]
    ItemSlot currentItemSlot;
    [SerializeField]
    GameObject windowChange;
    [SerializeField]
    GameObject weaponWarning;
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
    [Header("Weapons")]
    [SerializeField]
    List<ItemSlot> weaponSlots;

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
            case ItemType.Weapon:
                WeaponCheck();
                break;
            default:
                break;
        }
    }

    public void TakeWeapon(int n)
    {
        CheckForCurrentItem(weaponSlots[n]);
        weaponWarning.SetActive(false);
        foreach (ItemSlot slot in weaponSlots)
        {
            slot.GetComponent<Button>().enabled = false;
        }
    }

    void CheckForCurrentItem(ItemSlot currentSlot)
    {
        currentItemSlot = currentSlot;
        if (currentItemSlot.item == null && item!=null)
        {
            currentItemSlot.UpdateItem(item);
                    inventoryWindow.SetActive(false);
        }
        else
        {
            WindowChangeEnable();
        }
    }
    void WeaponCheck()
    {
        weaponWarning.SetActive(true);
        foreach (ItemSlot slot in weaponSlots)
        {
            slot.GetComponent<Button>().enabled = true;
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
        if (e)
        {
            currentItemSlot.UpdateItem(item);
        }
        inventoryWindow.SetActive(false);
        windowChange.SetActive(false);
    }
}
