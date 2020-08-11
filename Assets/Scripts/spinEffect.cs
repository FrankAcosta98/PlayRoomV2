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
    public float changeSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("Color_7BE80810", red);
        GetComponent<Light2D>().color = red;
        def = red;
        next = yellow;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Light2D>().color = def;
        def = Vector4.MoveTowards(def, next, changeSpeed);
        if(def==next){
            switch (next)
            {
                case (red):
                    {
                        next = yellow;
                        break;
                    }
                case (yellow):
                    {
                        next = yellow;
                        break;
                    }
                case (green):
                    {
                        next = yellow;
                        break;
                    }
                default:
            }
        }
    }

}
