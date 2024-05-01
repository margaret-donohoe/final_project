using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float playerHealth;
    public Image playerHealthBar;

    private Gun gun;
    private GameObject handguard;
    private GameObject mesh;
    private SkinnedMeshRenderer mr;

    public bool shielded = false;

    //private Animator playerAnimator;

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

        handguard = GameObject.Find("shotgun_handguard_001");
        mesh = GameObject.Find("player");
        mr = mesh.GetComponent<SkinnedMeshRenderer>();
        //dm = gameObject.GetComponentInParent<DialogueManager>();
        gun = gameObject.GetComponentInChildren<Gun>();
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
            SceneManager.LoadScene("GameOver");
        }
    }

    public void SetShield(bool b)
    {
        if(b == true)
        {
            shielded = true;
            gun.gameObject.layer = 3;
            handguard.gameObject.layer = 3;
            mr.enabled = false;
        }
        if (b == false)
        {
            shielded = false;
            gun.gameObject.layer = 0;
            handguard.gameObject.layer = 0;
            mr.enabled = true;
        }

        gun.SendShield(shielded);
    }

    public bool GetShield()
    {
        return shielded;
    }
}


