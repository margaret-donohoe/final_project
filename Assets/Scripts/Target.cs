using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public Image healthBar;
    private Transform player;
    public Animator enemyAnimator;

    public float damage;
    public PlayerHealth playerHealth;

    public float speed = 5f; 
    public float detectionRange = 10f;

    private bool isPlayerInRange = false;
    public AudioClip g6;

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
        CheckPlayerDistance();
        MoveTowardsPlayer();

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
        if(gameObject.name == "discoboss1")
        {
            SceneManager.LoadScene("Win");
        }
    }
    void CheckPlayerDistance()
    {
        // Calculate the distance from the current GameObject to the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the specified range
        if (distance <= detectionRange)
        {
            GameObject mc = GameObject.Find("MainCamera");
            if (gameObject.name == "discoboss1" && mc.GetComponent<AudioSource>().clip != g6)
            {
                mc.GetComponent<AudioSource>().clip = g6;
                mc.GetComponent<AudioSource>().Play();
            }
            isPlayerInRange = true;
            enemyAnimator.SetTrigger("awake");
            enemyAnimator.SetTrigger("attack");
        }
        else
        {
            isPlayerInRange = false;
        }

        if (player != null)
        {
            //Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;

            //Make the enemy always face the player (only rotate on the Y-axis)
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }

    void MoveTowardsPlayer()
    {
        // Move the GameObject towards the player if they are within range
        if (isPlayerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
