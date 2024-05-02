using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    public Button replayBtn;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        replayBtn.onClick.AddListener(replaygame);
    }

    // Call this method to go back to the previous scene
    public void Restart()
    {
        SceneManager.LoadScene("TransitionRoom");
    }

    void replaygame()
    {
        Restart();
    }
}
