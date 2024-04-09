using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public Image healthBar;
    public Gun gunScript;

    void Start()
    {

    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        if (health <=0)
        {
            healthBar.fillAmount = 100f;
            StartCoroutine(Die());
        }

    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
