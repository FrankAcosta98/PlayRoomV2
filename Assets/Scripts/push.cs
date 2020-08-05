using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && Vector2.Distance(other.gameObject.transform.position, gameObject.transform.position) < 3f)
        {
            if (other.gameObject.GetComponent<LightControl>().Holded == true)
            {
                other.gameObject.GetComponent<LightControl>().Holded = false;
                other.gameObject.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().pointLightOuterRadius = 2.8f;
            }
            other.gameObject.GetComponent<Animator>().SetBool("push", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player" && Vector2.Distance(other.gameObject.transform.position, gameObject.transform.position) >= 3f)
        {
            other.gameObject.GetComponent<Animator>().SetBool("push", false);
        }
    }
}
