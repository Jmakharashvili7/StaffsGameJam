using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
    [SerializeField]
    Health player;

    [Header("Player Stats")]
    [SerializeField]
    TMP_Text maxHealthTxt;
    [SerializeField]
    TMP_Text currentHealthTxt;
    [SerializeField]
    TMP_Text maxManaTxt;
    [SerializeField]
    TMP_Text currentManaTxt;
    [SerializeField]
    Image healthBar;
    [SerializeField]
    Image manaBar;

    [Header("Resources")]
    [SerializeField]
    TMP_Text coins;
    [SerializeField]
    TMP_Text stars;

    [Header("Wave")]
    [SerializeField]
    TMP_Text waveCount;
    [SerializeField]
    TMP_Text timeRemaining;

    private void Start()
    {
        player.OnUpdateHealth += Player_OnUpdateHealth;
        player.OnUpdateValues += Player_OnUpdateValues;
        player.UpdateValues();
        player.Heal(0);
    }

    private void Player_OnUpdateValues(object sender, System.EventArgs e)
    {
        UpdateValues();
    }

    private void Player_OnUpdateHealth(object sender, System.EventArgs e)
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        currentHealthTxt.text = player.currentHealth.ToString();
    }

    void UpdateValues()
    {
        maxHealthTxt.text = player.maxHealth.ToString();

    }

}
