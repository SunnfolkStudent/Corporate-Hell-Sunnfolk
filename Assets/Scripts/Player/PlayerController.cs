using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public int ammo;
    public float force = 5f;
    public int maxAmmo = 2;
    
    private InputManager _input;
    private Aim _aim;
    private Rigidbody2D _rigidbody2D;
    private bool _wasGrounded;

    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.55f, 0.1f);
    public int ammoSize = 2;

    private bool gunFired;
    

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _aim = GetComponent<Aim>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        ammo = ammoSize;
    }
    

    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        
        if (_input.Gun && ammo > 0)
        {
            gunFired = true;
            _rigidbody2D.linearVelocity = -_aim.Direction * force;
        }

        if (gunFired && !playerIsGrounded)
        {
            ammo--;
            gunFired = false;
        }

        if (playerIsGrounded && !_wasGrounded && ammo < ammoSize && !_input.Gun)
        {
            ammo = ammoSize;
        }

        _wasGrounded = playerIsGrounded;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, groundBoxSize);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Death"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
