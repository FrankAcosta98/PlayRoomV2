using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    private bool usable = false;
    Transform Player;
    public Rigidbody2D rb;
    private bool move = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && usable)
        { move = true; }
        if (Input.GetKeyUp(KeyCode.E) && usable)
        { move = false; }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (move && Vector2.Distance(Player.position, gameObject.transform.position) > 2.53f)
        {
            rb.MovePosition(Vector2.MoveTowards(gameObject.transform.position, Player.position, Player.GetComponent<MainChar>().spd * Time.fixedDeltaTime));
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            usable = true;
            Player = other.gameObject.transform;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            usable = false;
    }
}
