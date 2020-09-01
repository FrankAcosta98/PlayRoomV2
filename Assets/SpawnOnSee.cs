using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnSee : MonoBehaviour
{
    private bool spawned = false;
    private float cool = 0f;
    private float ready = 5f;
    public GameObject spin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawned && cool < ready)
        {
            cool += Time.deltaTime;
        }
        else if (cool >= ready)
        {
            cool = 0f;
            spawned = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && spawned == false)
        {
            
            GameObject.Instantiate(spin, transform.position, Quaternion.identity);
            
            spawned = true;
        }
    }
}
