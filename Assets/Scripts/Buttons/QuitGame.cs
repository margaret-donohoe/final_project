using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    void Start()
    {
        // Get the Button component and add a listener to it
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(QuittheGame);
    }

    void QuittheGame()
    {
        // Quit the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // For use in the editor
        Debug.Log("Quitting Application");
#else
        Application.Quit(); // For use in build
#endif
    }
}
