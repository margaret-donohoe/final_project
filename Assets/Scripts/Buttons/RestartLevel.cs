using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    private Stack<string> sceneHistory = new Stack<string>();  // Stack to keep track of scenes
    public Button replayBtn;
    void Start()
    {
        replayBtn.onClick.AddListener(replaygame);
    }

    // Call this method to load any new scene
    public void LoadScene(string newScene)
    {
        // Push the current scene to the stack
        sceneHistory.Push(SceneManager.GetActiveScene().name);
        // Load the new scene
        SceneManager.LoadScene(newScene);
    }

    // Call this method to go back to the previous scene
    public void LoadPreviousScene()
    {
        if (sceneHistory.Count > 0)
        {
            string previousScene = sceneHistory.Pop();
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.Log("No previous scene in the history.");
        }
    }
    void replaygame()
    {
        LoadPreviousScene();
    }
}
