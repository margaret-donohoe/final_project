using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float playerHealth;
    public Image playerHealthBar;

    public bool shielded = false;
    //private Animator playerAnimator;

    private void Start()
    {
        playerHealth = maxHealth;
        //playerAnimator = GetComponent<Animator>();
    }

    public void PlayerDamage(float damage)
    {
        if(shielded == true)
        {
            damage = damage / 2;
        }

        playerHealth -= damage;
        playerHealthBar.fillAmount = playerHealth / 100f;
        if (playerHealth <= 0)
        {
            Debug.Log("You Died.");
        }
    }

    public void SetShield(bool b)
    {
        if(b == true)
        {
            shielded = true;
        }
        if (b == false)
        {
            shielded = false;
        }
    }
}


