using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Image directions;
    private Color on = new Color(1, 1, 1, 1);
    private Color off = new Color(1, 1, 1, 0);
    private float alpha;
    // Start is called before the first frame update
    void Start()
    {
        directions.color = off;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(fadeOn());
        }
    }

    IEnumerator fadeOn()
    {
        while(directions.color.a<1)
        {
            Color fade = new Color(1, 1, 1, alpha + 0.025f);
            alpha = directions.color.a;
            directions.color = fade;
            yield return new WaitForSeconds(0.025f);
        }
        
    }
}
