using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemArgs : EventArgs
{
    public Item item;
}

public class CreatedItem : MonoBehaviour
{
    public event EventHandler<ItemArgs> OnItemTake;
    [Header("List Of items")]
    [SerializeField]
    Item item;
    [Header("Common")]
    [SerializeField]
    List<Item> commonItems;
    [Header("Uncommon")]
    [SerializeField]
    List<Item> uncommonItems;
    [Header("Rare")]
    [SerializeField]
    List<Item> rareItems;
    [Header("Epic")]
    [SerializeField]
    List<Item> epicItems;
    [Header("Legendary")]
    [SerializeField]
    List<Item> legendaryItems;
    [SerializeField]
    TMP_Text name;
    [SerializeField]
    Image icon;
    [SerializeField]
    TMP_Text bonus;

    public void TakeItem()
    {
        ItemArgs itemArgs = new ItemArgs();
        itemArgs.item = item;

        if (OnItemTake != null)
            OnItemTake(this, itemArgs);
    }

    private void OnEnable()
    {
        PickRandomItems();
    }

    void PickRandomItems()
    {
        item = commonItems[UnityEngine.Random.Range(0, commonItems.Count)];
        UpdateItemUI();
    }

    public void UpdateItemUI()
    {
        name.text = item.name;
        icon.sprite = item.icon;
        bonus.text = item.bonus;
        UpdateItemColor();
    }
    void UpdateItemColor()
    {
        switch(item.rarity)
        {
            case Rarity.Common:
                name.color = Color.white;
                break;
            case Rarity.Uncommon:
                name.color = Color.green;
                break;
            case Rarity.Rare:
                name.color = Color.blue;
                break;
            case Rarity.Epic:
                name.color = Color.magenta;
                break;
            case Rarity.Legendary:
                name.color = Color.yellow;
                break;
            default:
                name.color = Color.gray;
                break;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            UpdateItemUI();
        }
    }
}
