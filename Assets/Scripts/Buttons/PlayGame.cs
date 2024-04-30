using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Button playBtn;
    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener(playgame);
    }

    void playgame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
