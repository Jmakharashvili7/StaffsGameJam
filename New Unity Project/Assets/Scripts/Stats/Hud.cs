using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

class FillValues
{
    public float curentValue = 0;
    public float startValue = 0;
    public float timer = 0;
}


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
    Image healhtBarDelay;
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

    FillValues hpFill = new FillValues();
    FillValues manaFill = new FillValues();

    private void Start()
    {
        player.OnUpdateHealth += Player_OnUpdateHealth;
        player.OnUpdateValues += Player_OnUpdateValues;
        player.UpdateValues();
        player.Heal(0);
    }

    private void Update()
    {
        hpFill.timer += Time.deltaTime * 3f;
        healhtBarDelay.fillAmount = Mathf.Lerp(hpFill.startValue,hpFill.curentValue,hpFill.timer);
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
        if (player.currentHealth <= 0)
            GameManager.Instance.GetComponent<LevelManager>().LoadScene("CreditsOn");
        currentHealthTxt.text = player.currentHealth.ToString();
        healthBar.fillAmount = (float)player.currentHealth / (float)player.maxHealth;
        StartCoroutine(HpBarDelay());
    }

    void UpdateValues()
    {
        maxHealthTxt.text = player.maxHealth.ToString();
    }

    IEnumerator HpBarDelay()
    {
        yield return new WaitForSeconds(.25f);
        hpFill.curentValue = healthBar.fillAmount;
        hpFill.startValue = healhtBarDelay.fillAmount;
        hpFill.timer = 0;
    }
    
}
