using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Damage : MonoBehaviour
{
    [SerializeField]
    Stats stats;

    private void OnEnable()
    {
        stats = GetComponent<Stats>();
    }

    public int GiveDamage()
    {
        int damage = stats.attackDamage;
        if(Random.Range(0,100)<(stats.critChance+stats.luck/2))
        {
            damage += 2;
            damage += damage * (stats.critDamage / 100);
        }

        return damage;
    }
}
