using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Button playBtn;

    void Start()
    {
        playBtn.onClick.AddListener(playgame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playgame()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
