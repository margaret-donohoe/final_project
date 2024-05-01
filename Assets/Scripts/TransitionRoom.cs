using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class TransitionRoom : MonoBehaviour
{
    public StarterAssetsInputs starterAssetsInputs;
    private int transTime = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("recognizes door");
            if(transTime == 0)
            {
                transTime++;

                StartCoroutine(GoTohspLevel());
            }
            if (transTime == 1)
            {
                StartCoroutine(GoToclubLevel());
            }
        }
    }
    IEnumerator GoTohspLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("hsp");
    }
    IEnumerator GoToclubLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Club");
    }
}
