using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubDoorOpen : MonoBehaviour
{
    private Transform player;
    public Animator subAnimator;
    public float detectionRange = 10f;

    private bool isPlayerInRange = false;


    void Start()
    {
        subAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found.");
        }
    }


    void Update()
    {
        CheckPlayerDistance();
    }
    void CheckPlayerDistance()
    {
        // Calculate the distance from the current GameObject to the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the specified range
        if (distance <= detectionRange)
        {
            isPlayerInRange = true;
            subAnimator.SetTrigger("open");

        }
        else
        {
            isPlayerInRange = false;
            //subAnimator.SetTrigger("close");
        }
    }
}
