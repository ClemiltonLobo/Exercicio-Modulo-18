using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public TextMeshProUGUI uiTextMexhProCoins;
    public SOFloat _recoverLife;

    private void Start()
    {
        Reset();
    }


    private void Reset()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddLife(float amount = 1f)
    {
        HealthBase playerHealth = FindObjectOfType<HealthBase>();
        if (playerHealth != null)
        {
            playerHealth.Heal(amount);
        }
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }
    private void UpdateUI()
    {
        //uiTextMexhProCoins.text = coins.ToString();
        //UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }
    public float GetRecoverLifeAmount()
    {
        return _recoverLife.value;
    }
}
