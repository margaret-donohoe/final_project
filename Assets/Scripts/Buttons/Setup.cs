using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Setup : MonoBehaviour
{
    public TMP_Dropdown inputDropdown;

    private bool isKeyboardMouseEnabled = true;
    private bool isGamepadEnabled = true;


    void Start()
    {
        inputDropdown.onValueChanged.AddListener(delegate { ToggleInput(inputDropdown.value); });
    }

    private void ToggleInput(int choice)
    {
        isKeyboardMouseEnabled = false;
        isGamepadEnabled = false;


        switch (choice)
        {
            case 0: //Keyboard and Mouse Only
                isKeyboardMouseEnabled = true;
                break;
            case 1: //Gamepad Only
                isGamepadEnabled = true;
                break;
        }
    }

    void Update()
    {
        if (isKeyboardMouseEnabled)
        {

        }

        if (isGamepadEnabled)
        {

        }


    }
}

