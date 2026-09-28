using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public int ammo;
    public float force = 7f;
    public int maxAmmo = 2;
    
    private InputManager _input;
    private Aim _aim;
    private Rigidbody2D _rigidbody2D;
    private bool _wasGrounded;

    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(1f, 0.2f);
    

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _aim = GetComponent<Aim>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        ammo = 1;
    }
    

    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        
        if (_input.Gun && ammo > 0)
        {
            ammo--;
            _rigidbody2D.linearVelocity = -_aim.Direction * force;
        }

        if (playerIsGrounded && !_wasGrounded && ammo <= 0 && !_input.Gun)
        {
            ammo = 1;
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
