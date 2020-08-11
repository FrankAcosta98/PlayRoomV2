using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class spinEffect : MonoBehaviour
{
    public Color red;
    public Color blue;
    public Color green;
    public Color yellow;
    private Color def;
    private Color next;
    private Color full;
    public float changeSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("Color_7BE80810", red);
        GetComponent<Light2D>().color = red;
        def = red;
        next = yellow;
        //full.a;5882353
        full.a = 4117647;
        full.b = 0;
        full.g = 0;
        full.r = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(def.a);
        GetComponent<Renderer>().material.SetColor("Color_7BE80810", def+full);
        GetComponent<Light2D>().color = def;
        def = Vector4.MoveTowards(def, next, changeSpeed);
        
        if (def == next)
        {
            if (next == red)
            {
                next = yellow;
            }
            else if (next == yellow)
            {
                next = green;
            }
            else if (next == green)
            {
                next = blue;
            }
            else if (next == blue)
            {
                next = red;
            }
        }
    }

}
