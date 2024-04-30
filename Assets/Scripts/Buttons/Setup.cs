using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setup : MonoBehaviour
{
    public Dropdown inputDropdown;

    private bool isGamepadEnabled = true;
    private bool isKeyboardMouseEnabled = true;

    void Start()
    {
        inputDropdown.onValueChanged.AddListener(delegate { ToggleInput(inputDropdown.value); });
    }

    private void ToggleInput(int choice)
    {
        // Disable all inputs first
        isGamepadEnabled = false;
        isKeyboardMouseEnabled = false;

        // Enable selected input
        switch (choice)
        {
            case 0: // Keyboard and Mouse Only
                isKeyboardMouseEnabled = true;
                break;
            case 1: // Gamepad Only
                isGamepadEnabled = true;
                break;
        }
    }

    void Update()
    {
        if (isKeyboardMouseEnabled)
        {
            // Code to handle keyboard and mouse input
        }

        if (isGamepadEnabled)
        {
            // Code to handle gamepad input
        }


    }
}

