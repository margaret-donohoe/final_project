using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
using UnityEngine.UI;

public class MedicalChart : MonoBehaviour
{

    // Sets a Max Distance the door can be seen from.
    private bool inRange = false;
    private bool done = false;
    //public StarterAssetsInputs starterAssetsInputs;
    public Image chart;
    private Color cColor;
    public Image chartBG;
    private Color cbgColor;
    // Allows the Door Script to know if it's being Looked at right now
    private void Awake()
    {
        cColor = chart.color;
        cColor.a = 0f;
        chart.color = cColor;
        cbgColor = chartBG.color;
        cbgColor.a = 0f;
        chartBG.color = cbgColor;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && chart.color.a == 1f)
        {
            cColor.a = 0f;
            chart.color = cColor;
            cbgColor.a = 0f;
            chartBG.color = cbgColor;
            inRange = false;
            done = true;
            
        }

        else if (Input.GetButtonDown("Cancel") && inRange == true)
        {
            cColor.a = 1f;
            chart.color = cColor;
            cbgColor.a = 0.9f;
            chartBG.color = cbgColor;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && done == false)
        {
            inRange = true;
        }
    }
}