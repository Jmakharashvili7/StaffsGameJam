using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public event EventHandler OnUpdateHealthValues;
    public event EventHandler OnUpdateManaValues;
    public event EventHandler OnUpdateDamageValues;
    public event EventHandler OnUpdateUtilityValues;

    [Header("Health")]
    public int maxHealth;
    public int regenHealth;
    public int armor;
    public int lifeSteal;

    [Header("Mana")]
    public int maxMana;
    public int regenMana;
    public int ablityDamage;

    [Header("Damage")]
    public int attackDamage;
    public int attackSpeed;
    public int critChance;
    public int critDamage;

    [Header("Utility")]
    public int movementSpeed;
    public int dodgeChance;
    public int luck;

    public void UpdateHealthValues(int cMaxHealth, int cRegenHealth, int cArmor, int cLifeSteal)
    {
        maxHealth += cMaxHealth;
        regenHealth += cRegenHealth;
        armor += cArmor;
        lifeSteal += cLifeSteal;

        if (OnUpdateHealthValues != null)
            OnUpdateHealthValues(this, EventArgs.Empty);
    }

    public void UpdateManaValues(int cMaxMana, int cRegenMana, int cAblityDamage)
    {
        maxMana += cMaxMana;
        regenMana += cRegenMana;
        ablityDamage += cAblityDamage;

        if(OnUpdateManaValues != null)
            OnUpdateHealthValues(this,EventArgs.Empty);
    }

    public void UpdateDamageValues(int cAttackDamage, int cAttackSpeed, int cCritChance, int cCritDamage)
    {
        attackDamage += cAttackDamage;
        attackSpeed += cAttackSpeed;
        critChance += cCritChance;
        critDamage += cCritDamage;

        if (OnUpdateDamageValues != null)
            OnUpdateDamageValues(this, EventArgs.Empty);
    }

    public void UpdateUtilityValues(int cMovementSpeed, int cDodgeChance, int cLuck)
    {
        movementSpeed += cMovementSpeed;
        dodgeChance += cDodgeChance;
        luck += cLuck;
        
        if(OnUpdateUtilityValues!=null)
            OnUpdateUtilityValues(this, EventArgs.Empty);
    }

    public void Refresh()
    {
        UpdateDamageValues(0, 0, 0, 0);
        UpdateHealthValues(0, 0, 0, 0);
        UpdateManaValues(0, 0, 0);
        UpdateUtilityValues(0, 0, 0);
    }
}