using System.Data.Common;
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
    public Rigidbody2D rb;

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grab.IsTouchingLayers(8));
        if (usable && Input.GetKeyDown(KeyCode.E))
        {
            usable = false;
            holded = true;
            hitbox.enabled = false;
            grab.enabled = false;
            detect.enabled = false;
            //GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (holded && Input.GetKeyDown(KeyCode.E) && usable == false)
        {
            hitbox.enabled = true;
            holded = false;
            //grab.enabled = true;
            detect.enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            if (Player.GetComponent<MainChar>().face == "r")
                rb.AddForce(Vector3.right * 6969);
            if (Player.GetComponent<MainChar>().face == "l")
                rb.AddForce(Vector3.left * 6969);
            if (Player.GetComponent<MainChar>().face == "f")
                rb.AddForce(Vector3.up * 6969);
            if (Player.GetComponent<MainChar>().face == "b")
                rb.AddForce(Vector3.down * 6969);
        }
        if (holded)
        {
            if (Player.GetComponent<MainChar>().face == "r")
                gameObject.transform.position = Player.transform.position + Vector3.right;
            if (Player.GetComponent<MainChar>().face == "l")
                gameObject.transform.position = Player.transform.position + Vector3.left;
            if (Player.GetComponent<MainChar>().face == "f")
                gameObject.transform.position = Player.transform.position + Vector3.up;
            if (Player.GetComponent<MainChar>().face == "b")
                gameObject.transform.position = Player.transform.position + (Vector3.down * 2f);

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
