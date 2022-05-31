using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    Image icon;
    [SerializeField]
    Stats player;

    public Item item;

    private void Start()
    {
        player = GameManager.Instance.player;
    }

    public void UpdateItem(Item newItem)
    {
        if(item!=null)
        {
            
            player.UpdateHealthValues(-item.maxHealth, -item.regenHealth, -item.armor, item.lifeSteal);
            player.UpdateManaValues(-item.maxMana, -item.regenMana, -item.ablityDamage);
            player.UpdateDamageValues(-item.attackDamage, -item.attackSpeed, -item.critChance, -item.critDamage);
            player.UpdateUtilityValues(-item.movementSpeed, -item.dodgeChance, -item.luck);
        }

        item = newItem;
        icon.sprite = item.icon;

        player.UpdateHealthValues(item.maxHealth, item.regenHealth, item.armor, item.lifeSteal);
        player.UpdateManaValues(item.maxMana, item.regenMana, item.ablityDamage);
        player.UpdateDamageValues(item.attackDamage, item.attackSpeed, item.critChance, item.critDamage);
        player.UpdateUtilityValues(item.movementSpeed, item.dodgeChance, item.luck);
    }
}
