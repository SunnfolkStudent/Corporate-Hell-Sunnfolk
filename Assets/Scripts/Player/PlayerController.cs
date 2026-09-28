using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputManager _input;
    private Rigidbody2D _rb;
    
    public int ammo;
    public float force = 7f;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_input.Gun)
        {
            _rb.linearVelocityY = force;
            print("Gun fired");
        }
    }
}
