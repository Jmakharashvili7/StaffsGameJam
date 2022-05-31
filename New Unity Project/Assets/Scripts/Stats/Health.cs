using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Health : MonoBehaviour
{
    public event EventHandler OnUpdateHealth;
    public event EventHandler OnUpdateValues;

    Stats stats;
    public int maxHealth;
    public int currentHealth;
    public int regenHealth;
    public int armor;
    public int dodgeChance;
    public int luck;

    private void Stats_OnUpdateUtilityValues(object sender, EventArgs e)
    {
        UpdateValues();
    }

    private void Stats_OnUpdateHealthValues(object sender, EventArgs e)
    {
        UpdateValues();
    }

    private void OnEnable()
    {
        stats = GetComponent<Stats>();
        stats.OnUpdateHealthValues += Stats_OnUpdateHealthValues;
        stats.OnUpdateUtilityValues += Stats_OnUpdateUtilityValues;
        stats.Refresh();
        StartCoroutine(C_RegenHealth());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        stats.OnUpdateHealthValues -= Stats_OnUpdateHealthValues;
        stats.OnUpdateUtilityValues -= Stats_OnUpdateUtilityValues;
    }

    public void UpdateValues()
    {
        maxHealth = stats.maxHealth;
        currentHealth = maxHealth;
        armor = stats.armor;
        dodgeChance = stats.dodgeChance;
        luck = stats.luck;
        regenHealth = stats.regenHealth;

        if (OnUpdateValues != null)
            OnUpdateValues(this, EventArgs.Empty);
    }

    public void TakeDamage(int damage)
    {
        if ((dodgeChance + (luck / 2)) >= UnityEngine.Random.Range(0, 100)) // Dodge
            return;
        if (armor >= damage) // Armor blocked all the damage
            return;

        currentHealth -= (damage - armor);
        
        if(currentHealth <= 0)
        {
            //RIP
        }

        if (OnUpdateHealth != null)
            OnUpdateHealth(this, EventArgs.Empty);
    }

    public void Heal(int num)
    {
        currentHealth += num;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (OnUpdateHealth != null)
            OnUpdateHealth(this, EventArgs.Empty);
    }

    IEnumerator C_RegenHealth()
    {
        yield return new WaitForSeconds(5f);
        Heal(regenHealth);

        StartCoroutine(C_RegenHealth());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            TakeDamage(10);
    }
}
