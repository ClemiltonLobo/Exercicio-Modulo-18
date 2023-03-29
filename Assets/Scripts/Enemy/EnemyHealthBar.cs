using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform enemy;
    public float yOffset = 2f;
    public Image healthBar;

    private void LateUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(enemy.position + Vector3.up * yOffset);
        transform.position = screenPos;
        healthBar.fillAmount = enemy.GetComponent<HealthBase>()._currentLife / enemy.GetComponent<HealthBase>().startLife;
    }
}
