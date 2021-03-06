using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Experience : MonoBehaviour
{
    [Header("Data")]
    [SerializeField]
    int level;
    [SerializeField]
    int experience;
    [SerializeField]
    int experienceRequired;
    [Header("UI")]
    [SerializeField]
    TMP_Text levelText;
    [SerializeField]
    Image experienceBar;

    private void Start()
    {
        AddExperience(0);
    }
    public void AddExperience(int amount)
    {
        experience += amount;
        while (experience >= experienceRequired)
            LevelUp();
        experienceBar.fillAmount = ((float)experience / (float)experienceRequired)*0.75f;

    }    
    void LevelUp()
    {
        GameManager.Instance.GetComponent<Inventory>().inventoryWindow.SetActive(true);
        level++;
        levelText.text = level.ToString();
        experience -= experienceRequired;
        experienceRequired += 200;
    }
    public int getLevel() { return level; }
}