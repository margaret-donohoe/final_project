using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the slider

    void Start()
    {
        PlayerPrefs.SetFloat("volume", 1);
        // Initialize slider value to the current volume
        volumeSlider.value = AudioListener.volume;

        // Add a listener to handle volume change
        volumeSlider.onValueChanged.AddListener(HandleVolumeChange);
    }

    private void HandleVolumeChange(float value)
    {
        // Set the volume based on the slider's value
        PlayerPrefs.SetFloat("volume", value);
        AudioListener.volume = value;
    }
}
