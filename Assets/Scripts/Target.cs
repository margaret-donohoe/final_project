using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50;
    public Image healthBar;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <=0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
