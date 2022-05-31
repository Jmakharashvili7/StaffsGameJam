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
        int level = GameManager.Instance.player.GetComponent<Experience>().getLevel();
        int rarity = UnityEngine.Random.Range((0 + (level * 2)), (12 + level));

        if (rarity <= 4)
        {
            item = commonItems[UnityEngine.Random.Range(0, commonItems.Count)];
        }
        else if (rarity > 4 && rarity <= 8)
        {
            item = uncommonItems[UnityEngine.Random.Range(0, uncommonItems.Count)];
        }
        else if (rarity>8 && rarity <=11)
        {
            item = rareItems[UnityEngine.Random.Range(0, rareItems.Count)];
        }
        else if(rarity > 11 && rarity <=13)
        {
            item = epicItems[UnityEngine.Random.Range(0, epicItems.Count)];
        }
        else
        {
            item = legendaryItems[UnityEngine.Random.Range(0, legendaryItems.Count)];
        }
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
