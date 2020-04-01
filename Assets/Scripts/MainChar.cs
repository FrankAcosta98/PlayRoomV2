using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MainChar : MonoBehaviour
{
    public Rigidbody2D rb;
    public float spd;
    CharCrt Input;
    Vector2 move;
    void Awake()
    {
        Input = new CharCrt();
        Input.Control.move.performed += ctx => move = ctx.ReadValue<Vector2>();
    }
    void Update()
    {
        rb.MovePosition(rb.position + move * spd * Time.deltaTime);
    }
    void OnEnable()
    {
        Input.Enable();
    }
    void OnDisable()
    {
        Input.Disable();
    }
}
