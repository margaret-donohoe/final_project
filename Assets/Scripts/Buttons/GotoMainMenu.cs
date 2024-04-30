using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes
using UnityEngine.UI;

public class GotoMainMenu : MonoBehaviour
{
    public Button mainmenuBtn;

    void Start()
    {
        mainmenuBtn.onClick.AddListener(playgame);
    }

    void playgame()
    {
        SceneManager.LoadScene("Start");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
