using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    private bool usable = false;
    GameObject Player;
    public Rigidbody2D rb;
    private bool move = false;
    private bool holded = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (usable && Input.GetKeyDown(KeyCode.E))
        {
            usable = false;
            move = true;
            holded = true;

        }
        else if (holded && Input.GetKeyDown(KeyCode.E) && usable == false)

        {
            move = false;
            holded = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (move && Vector2.Distance(Player.transform.position, gameObject.transform.position) > 2.53f)
        {
            rb.MovePosition(Vector2.MoveTowards(gameObject.transform.position, Player.transform.position, Player.GetComponent<MainChar>().spd * Time.fixedDeltaTime));
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
