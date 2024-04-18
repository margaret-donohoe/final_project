using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public Image healthBar;
    private Transform player;
    public Animator enemyAnimator;

    public float damage;
    public PlayerHealth playerHealth;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found.");
        }
    }
     void Update()
    {
        if (player != null)
        {
            //Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;

            //Make the enemy always face the player (only rotate on the Y-axis)
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player gets attacked by enemy");
            playerHealth.PlayerDamage(damage);

        }
    }

    public void TakeDamage(float amount)
    {
        enemyAnimator.SetTrigger("attack");

        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        if (health <=0)
        {
            enemyAnimator.SetTrigger("die");
            StartCoroutine(Die());
        }

    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }

}
