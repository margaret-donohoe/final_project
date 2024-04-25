using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class DoorInteractor : MonoBehaviour
{

    // Sets a Max Distance the door can be seen from.
    public bool hitDoor = false;
    public StarterAssetsInputs starterAssetsInputs;
    // Allows the Door Script to know if it's being Looked at right now

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && hitDoor == true)
        {
            Debug.Log("recognizes door");
            SceneManager.LoadScene("hsp");
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            hitDoor = true;
        }
    }
}