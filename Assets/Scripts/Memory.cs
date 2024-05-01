using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    private string n;
    private string k;

    // Start is called before the first frame update
    void Awake()
    {
        n = gameObject.name;
        SetKnot(n);
    }

    // Update is called once per frame
    public void SetKnot(string name)
    {
        //string knot = "";

        if(name == "nurse")
        {
            k = "enter";
        }

        if (name == "Slender")
        {
            k = "tutorial";
        }

        else if (name == "mom")
        {
            k = "tutorial";
        }

        else if (name == "dad")
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
