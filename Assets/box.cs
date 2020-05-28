using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private bool usable = false;
    private bool holded = false;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (usable && Input.GetKeyDown(KeyCode.E))
        {
            holded = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (holded && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (holded)
        {
            gameObject.transform.position = Player.transform.position;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && Vector2.Distance(other.gameObject.transform.position, gameObject.transform.position) < 3f)
        {
            Player = other.gameObject;
            usable = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player" && Vector2.Distance(other.gameObject.transform.position, gameObject.transform.position) >= 3f)
            usable = false;
    }
}
