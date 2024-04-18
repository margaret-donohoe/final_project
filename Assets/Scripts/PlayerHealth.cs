using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float playerHealth;
    public Image playerHealthBar;
    //private Animator playerAnimator;

    private void Start()
    {
        playerHealth = maxHealth;
        //playerAnimator = GetComponent<Animator>();
    }

    public void PlayerDamage(float damage)
    {
        playerHealth -= damage;
        playerHealthBar.fillAmount = playerHealth / 100f;
        if (playerHealth <= 0)
        {
            Debug.Log("You Died.");
        }
    }

}


