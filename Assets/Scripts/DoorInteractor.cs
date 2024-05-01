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

    public Scene current;
    // Allows the Door Script to know if it's being Looked at right now

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && hitDoor == true)
        {
            current = SceneManager.GetActiveScene();
            string n = current.name;
            if(n == "Tutorial")
            {
                StartCoroutine(GoToTR1());
            }
            if (n == "hsp")
            {
                StartCoroutine(GoToTR2());
            }
            if (n == "TransitionRoom")
            {
                StartCoroutine(GoToLevel1());
            }
            if (n == "TransitionRoom1")
            {
                StartCoroutine(GoToLevel2());
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            hitDoor = true;
        }
    }

    IEnumerator GoToTR1()
    {
        open.Play();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("TransitionRoom");
    }
    IEnumerator GoToTR2()
    {
        open.Play();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("TransitionRoom1");
    }
    IEnumerator GoToLevel1()
    {
        open.Play();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("hsp");
    }
    IEnumerator GoToLevel2()
    {
        open.Play();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Club");
    }

}