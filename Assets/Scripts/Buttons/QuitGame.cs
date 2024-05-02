using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Get the Button component and add a listener to it
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(QuittheGame);
    }

    void QuittheGame()
    {
        Application.Quit();
    }
}
