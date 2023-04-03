using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBase : MonoBehaviour
{
    public Action onKill;

    public float startLife;
    public bool destroyOnKill = false;
    public float delayToKill = 0f;
    public Image uiHealthBarImage;

    public float _currentLife;
    private bool _isDead = false;
    [SerializeField] FlashColor _flashColor;

    private void Awake()
    {
        Init();
        if (_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
        UpdateHealthBar();
        // Busca a refer�ncia para o player
        var player = GameObject.Find("PlayerObjectName");

        // Obt�m o componente HealthBase do player
        var playerHealth = player.GetComponent<HealthBase>();

        // Chama o m�todo Heal() do componente HealthBase para curar o player
        playerHealth.Heal(10f);
    }

    public void UpdateHealthBar()
    {
        float fillAmount = _currentLife / startLife;
        uiHealthBarImage.fillAmount = fillAmount;
    }

    public void Heal(float amount)
    {
        if (_currentLife + amount > startLife)
        {
            _currentLife = startLife;
        }
        else
        {
            _currentLife += amount;
        }
        UpdateHealthBar();

        if (uiHealthBarImage.fillAmount == 1)
        {

        }
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;
        if (_currentLife <= 0)
        {
            Kill();
        }

        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
        UpdateHealthBar();
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
        //if(onKill != null) onKill.Invoke();
        onKill?.Invoke();
    }
}

