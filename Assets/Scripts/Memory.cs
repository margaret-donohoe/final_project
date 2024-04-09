using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    private string n;
    private string k;
    // Start is called before the first frame update
    void Start()
    {
        n = gameObject.name;
        SetKnot(n);
    }

    // Update is called once per frame
    public void SetKnot(string name)
    {
        string knot;

        if(name == "nurse")
        {
            knot = "enter";
        }
        else
        {
            knot = "";
        }

        k = knot;
    }

    public string GetKnot()
    {
        return k;
    }
}
