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
        k = SetKnot(n);
    }

    // Update is called once per frame
    public string SetKnot(string name)
    {
        string knot;
        if(name == "nurse")
        {
            knot = "talk_to_nurse";
        }
        else
        {
            knot = "";
        }

        return knot;
    }

    public string GetKnot()
    {
        return k;
    }
}
