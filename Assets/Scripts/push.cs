using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player" && Vector2.Distance(other.gameObject.transform.position, gameObject.transform.position) < 3f)
        {
            if (other.gameObject.GetComponent<LightControl>().Holded == true)
            {
                other.gameObject.GetComponent<LightControl>().Holded = false;
                other.gameObject.GetComponent<LightControl>().lt.pointLightOuterRadius = 2.8f;
            }
            other.gameObject.GetComponent<Animator>().SetBool("push", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<Animator>().SetBool("push", false);
            //other.gameObject.GetComponent<Animator>().Play("Ted 0", 0);

        }
    }


}
