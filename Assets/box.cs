using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private bool usable = false;
    private bool holded = false;
    public Collider2D hitbox;
    public Collider2D grab;
    public CircleCollider2D detect;

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (usable && Input.GetKeyDown(KeyCode.E))
        {
            usable = false;
            holded = true;
            hitbox.enabled = false;
            grab.enabled = false;
            detect.enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (holded && Input.GetKeyDown(KeyCode.E)&&usable==false)
        {
            hitbox.enabled = true;
            holded = false;
            grab.enabled = true;
            detect.enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
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
