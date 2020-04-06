using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Hunt : MonoBehaviour
{
    public AIDestinationSetter destination;
    // Start is called before the first frame update
    void Start()
    {
        destination.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        destination.enabled = true;
    }
}
