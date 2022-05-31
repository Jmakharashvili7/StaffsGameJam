using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    Helmet,
    Chestplate,
    Leggings,
    Boots,
    Ring,
    Belt,
    Neck,
    Weapon,
    Spell
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    public string name;
    [TextArea]
    public string bonus;
    public Sprite icon;

    public ItemType itemType;
    public Rarity rarity;


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
