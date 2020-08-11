using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class spinEffect : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("tone", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
