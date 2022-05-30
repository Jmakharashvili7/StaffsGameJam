using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Health : MonoBehaviour
{
    Stats stats;
    [SerializeField]
    int maxHealth;
    [SerializeField]
    int currentHealth;
    [SerializeField]
    int regenHealth;
    [SerializeField]
    int armor;
    [SerializeField]
    int dodgeChance;
    [SerializeField]
    int luck;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    private void OnEnable()
    {
        UpdateValues();
        if(regenHealth>0)
            StartCoroutine(C_RegenHealth());
    }

    public void UpdateValues()
    {
        maxHealth = stats.maxHealth;
        currentHealth = maxHealth;
        armor = stats.armor;
        dodgeChance = stats.dodgeChance;
        luck = stats.luck;
        regenHealth = stats.regenHealth;
    }

    public void TakeDamage(int damage)
    {
        if ((dodgeChance + (luck / 2)) >= Random.Range(0, 100)) // Dodge
            return;
        if (armor >= damage) // Armor blocked all the damage
            return;

        currentHealth -= (damage - armor);
    }

    IEnumerator C_RegenHealth()
    {
        yield return new WaitForSeconds(1f);
        currentHealth += regenHealth;
        StartCoroutine(C_RegenHealth());
    }


}
