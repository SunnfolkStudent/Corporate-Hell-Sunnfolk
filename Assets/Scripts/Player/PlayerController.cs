using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public int ammo;
    public float force = 6f;
    public int ammoSize = 2;
    public float shootDistance = 4f;
    
    private InputManager _input;
    private Aim _aim;
    private Rigidbody2D _rigidbody2D;
    private bool _wasGrounded;

    public bool playerIsGrounded;
    public Transform groundCheck;
    public Transform theGun;
    public LayerMask whatIsGround;
    public LayerMask whatIsEnemy;
    public Vector2 groundBoxSize = new Vector2(0.55f, 0.1f);
    
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
        
        var hitInfo = Physics2D.Raycast(transform.position, _aim.Direction, shootDistance, whatIsEnemy);
        
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        
        if (_input.Gun && ammo > 0)
        {
            gunFired = true;
            if (hitInfo.collider != null)
            {
                Destroy(hitInfo.collider.gameObject);
                ammo =  ammoSize;
            }
            _rigidbody2D.linearVelocity = -_aim.Direction * force;
        }

        if (gunFired && !playerIsGrounded)
        {
            if (hitInfo.collider == null)
            {
                ammo--;
            }
            gunFired = false;
        }

        if (playerIsGrounded && !_wasGrounded && ammo < ammoSize && !_input.Gun)
        {
            ammo = ammoSize;
        }

        _wasGrounded = playerIsGrounded;
    }

    //private void FixedUpdate()
    //{
    //    theGun.position = new Vector3(_aim.Direction.x * _rigidbody2D.position.x, _aim.Direction.y * _rigidbody2D.position.y + 0.1f, 0.1f);
    //    theGun.rotation = new Quaternion(_aim.Direction.x, _aim.Direction.y, 0.1f, 0.1f);
    //}

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
