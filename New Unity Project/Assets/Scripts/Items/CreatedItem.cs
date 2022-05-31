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
    [SerializeField]
    Item item;
    [SerializeField]
    TMP_Text name;
    [SerializeField]
    Image icon;
    [SerializeField]
    TMP_Text bonus;
    [SerializeField]
    ItemType itemtype;

    public void TakeItem()
    {
        ItemArgs itemArgs = new ItemArgs();
        itemArgs.item = item;

        if (OnItemTake != null)
            OnItemTake(this, itemArgs);
    }

    private void OnEnable()
    {
        UpdateItemUI();
    }

    public void UpdateItemUI()
    {
        name.text = item.name;
        icon.sprite = item.icon;
        bonus.text = item.bonus;
        itemtype = item.itemType;
    }
}
