using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    private bool usable = false;
    GameObject Player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E) && usable)
        {
            rb.MovePosition(rb.position + Player.GetComponent<MainChar>().move * Player.GetComponent<MainChar>().spd * Time.fixedDeltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            usable = true;
            Player = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            usable = false;
    }
}
