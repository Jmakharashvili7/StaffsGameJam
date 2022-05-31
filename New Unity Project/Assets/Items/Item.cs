using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    public string name;
    [TextArea]
    public string bonus;
    public Sprite icon;

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

}
