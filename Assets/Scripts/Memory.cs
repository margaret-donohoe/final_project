using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    public string n;
    private string k;


    // Start is called before the first frame update
    void Awake()
    {
        SetKnot(n);
    }

    // Update is called once per frame
    public void SetKnot(string name)
    {
        //string knot = "";

        if (name == "Slender")
        {
            k = "tutorial";
        }

        else if (name == "mom")
        {
            k = "mummy";
        }

        else if (name == "dad")
        {
            k = "daddy";
        }
        
        else if (name == "jessica1")
        {
            k = "jess";
        }

        else if (name == "jessica2")
        {
            k = "j_bathroom";
        }

        else
        {
            k = "";
        }
    }

    public string GetKnot()
    {
        return k;
    }
}
