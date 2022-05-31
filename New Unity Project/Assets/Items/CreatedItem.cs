using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreatedItem : MonoBehaviour
{
    [SerializeField]
    Item item;
    [SerializeField]
    TMP_Text name;
    [SerializeField]
    Image icon;
    [SerializeField]
    TMP_Text bonus;

    [SerializeField]
    Stats player;
    private void Start()
    {
        player = GameManager.Instance.player;
    }
    public void TakeItem()
    {
        player.UpdateHealthValues(item.maxHealth, item.regenHealth,item.armor, item.lifeSteal);
        player.UpdateManaValues(item.maxMana, item.regenMana, item.ablityDamage);
        player.UpdateDamageValues(item.attackDamage, item.attackSpeed, item.critChance, item.critDamage);
        player.UpdateUtilityValues(item.movementSpeed, item.dodgeChance, item.luck);
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
    }
}
