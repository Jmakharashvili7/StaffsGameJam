using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatsUI : MonoBehaviour
{
    [SerializeField]
    Stats playerStats;

    [Header("Health")]
    [SerializeField] TMP_Text maxHealthTxt;
    [SerializeField] TMP_Text regenHealthTxt;
    [SerializeField] TMP_Text armorTxt;
    [SerializeField] TMP_Text lifeStealTxt;

    [Header("Mana")]
    [SerializeField] TMP_Text maxManaTxt;
    [SerializeField] TMP_Text regenManaTxt;
    [SerializeField] TMP_Text ablityDamageTxt;

    [Header("Damage")]
    [SerializeField] TMP_Text attackDamageTxt;
    [SerializeField] TMP_Text attackSpeedTxt;
    [SerializeField] TMP_Text critChanceTxt;
    [SerializeField] TMP_Text critDamageTxt;

    [Header("Utility")]
    [SerializeField] TMP_Text movementSpeedTxt;
    [SerializeField] TMP_Text dodgeChanceTxt;
    [SerializeField] TMP_Text luckTxt;

    private void Start()
    {
        playerStats.OnUpdateHealthValues += PlayerStats_OnUpdateHealthValues;
        playerStats.OnUpdateManaValues += PlayerStats_OnUpdateManaValues;
        playerStats.OnUpdateDamageValues += PlayerStats_OnUpdateDamageValues;
        playerStats.OnUpdateUtilityValues += PlayerStats_OnUpdateUtilityValues;

        UpdateHealthValues();
        UpdateManaValues();
        UpdateDamageValues();
        UpdateUtilityValues();
    }

    private void PlayerStats_OnUpdateUtilityValues(object sender, EventArgs e)
    {
        UpdateUtilityValues();
    }

    private void PlayerStats_OnUpdateDamageValues(object sender, EventArgs e)
    {
        UpdateDamageValues();
    }

    private void PlayerStats_OnUpdateManaValues(object sender, EventArgs e)
    {
        UpdateManaValues();
    }

    private void PlayerStats_OnUpdateHealthValues(object sender, EventArgs e)
    {
        UpdateHealthValues();
    }

    void UpdateHealthValues()
    {
        maxHealthTxt.text = playerStats.maxHealth.ToString();
        regenHealthTxt.text = playerStats.regenHealth.ToString();
        armorTxt.text = playerStats.armor.ToString();
        lifeStealTxt.text = playerStats.lifeSteal.ToString();
    }

    void UpdateManaValues()
    {
        maxManaTxt.text = playerStats.maxMana.ToString();
        regenManaTxt.text = playerStats.regenMana.ToString();
        ablityDamageTxt.text = playerStats.ablityDamage.ToString();
    }

    void UpdateDamageValues()
    {
        attackDamageTxt.text=playerStats.attackDamage.ToString();
        attackSpeedTxt.text=playerStats.attackSpeed.ToString();
        critChanceTxt.text=playerStats.critChance.ToString();
        critDamageTxt.text=playerStats.critDamage.ToString();
    }
    
    void UpdateUtilityValues()
    {
        movementSpeedTxt.text = playerStats.movementSpeed.ToString();
        dodgeChanceTxt.text = playerStats.dodgeChance.ToString();
        luckTxt.text = playerStats.luck.ToString();
    }
}
