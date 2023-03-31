using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollactableRecoverLife : ItemCollactableBase
{
    public float recoverAmount = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthBase health = other.gameObject.GetComponent<HealthBase>();
        if (health != null)
        {
            if (other.CompareTag("Player"))
            {
                health.Heal(recoverAmount);
                Debug.Log("Voc� coletou uma cura");
                Destroy(gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                // N�o faz nada, j� que inimigos n�o podem coletar cura
            }
        }
    }
}
