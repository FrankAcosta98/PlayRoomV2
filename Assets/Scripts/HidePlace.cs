using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlace : MonoBehaviour
{
    [Header("Components")]
    //public Animator anim;
    //public Sprite seeing;
    //public Sprite notSeeing;

    private bool usable = false;
    private bool hided = false;
    private GameObject coso;
    void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("hiding", false);
    }

    void Update()
    {
        // Mientras el jugador este escondido no se mueve hasta volver a oprimir el boton
        if (usable && Input.GetKeyDown(KeyCode.E))
        {
            //anim.SetBool("hiding", true);
            MainChar.instace.GetComponent<PolygonCollider2D>().enabled = false;
            MainChar.instace.GetComponent<SpriteRenderer>().enabled = false;
            hided = true;
            //MainChar.instace.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
            //desactivar luz
        }


        else if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && hided)
        {
            //anim.SetBool("hiding", false);
            MainChar.instace.GetComponent<PolygonCollider2D>().enabled = true;
            MainChar.instace.GetComponent<SpriteRenderer>().enabled = true;
            //MainChar.instace.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
            hided = false;
            MainChar.instace.GetComponent<Transform>().tag = "detectable";
            
            //desactivar luz
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Al entrar en contacto y interactuan el other se vuelve player y hiding se activa
        if (other.gameObject.name.Equals("Player"))
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = seeing;
            usable = true;
            coso = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = notSeeing;
            usable = false;
        }
    }
}