using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class spinEffect : MonoBehaviour
{
    private GameObject Player;
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

        //GetComponent<Renderer>().material.SetColor("Color_7BE80810", Color.red);
        GetComponent<Light2D>().color = red;
        def = red;
        next = yellow;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(def.a+full.a);
        //GetComponent<Renderer>().material.SetColor("Color_7BE80810", def+full);
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && Vector2.Distance(other.gameObject.transform.position, gameObject.transform.position) < 2f)
        {
            Player = other.gameObject;
            Player.GetComponent<MainChar>().move *= -1;
            Destroy(gameObject, 0.5f);
        }
    }
}
