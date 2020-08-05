using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class pushbox : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player" && Vector2.Distance(other.gameObject.transform.position, gameObject.transform.position) < 1.9f)
        {
            other.gameObject.GetComponent<Animator>().SetBool("push", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<Animator>().SetBool("push", false);
            other.gameObject.GetComponent<Animator>().Play("push 0", 0);

        }
    }


}
