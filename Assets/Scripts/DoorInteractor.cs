using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
using System.Collections;

public class DoorInteractor : MonoBehaviour
{
    // Sets a Max Distance the door can be seen from.
    public bool hitDoor = false;
    public StarterAssetsInputs starterAssetsInputs;
    public AudioSource open;
    // Allows the Door Script to know if it's being Looked at right now

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && hitDoor == true)
        {
            Debug.Log("recognizes door");
            StartCoroutine(GoToLevel());
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            hitDoor = true;
        }
    }

    IEnumerator GoToLevel()
    {
        open.Play();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("TransitionRoom");
    }
}