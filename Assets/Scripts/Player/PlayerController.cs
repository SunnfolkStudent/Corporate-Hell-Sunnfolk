using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    public RawImage ammoImage1;
    public RawImage ammoImage2;
    public RawImage ammoImage3;
    public LayerMask whatIsGround;
    public LayerMask whatIsEnemy;
    public Vector2 groundBoxSize = new Vector2(0.55f, 0.1f);
    public GameObject gunShooting;
    public Transform theGun;

    public AudioClip gunShot;
    public AudioClip[] dyingSounds;
    
    private Animator _animator;
    private AudioSource _audioSource;
    

    private bool gunFired;


    private void Start()
    {
        _input = GetComponent<InputManager>();
        _aim = GetComponent<Aim>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
        _animator.Play("Jim_Idle");

        ammo = ammoSize;
    }


    private void Update()
    {

        if (_input.Menu)
        {
            SceneManager.LoadScene("MainScene");
        }
       
        var hitInfo = Physics2D.Raycast(transform.position, _aim.Direction, shootDistance, whatIsEnemy);

        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);

        if (_input.Gun && ammo > 0)
        {
            gunFired = true;
            _audioSource.PlayOneShot(gunShot);
            if (hitInfo.collider != null)
            {
                Destroy(hitInfo.collider.gameObject);
                ammo = ammoSize;
            }

            _rigidbody2D.linearVelocity = -_aim.Direction * force;
            GameObject newShooting = Instantiate(gunShooting, _aim.crosshair.position, theGun.rotation, _aim.crosshair.parent);
            Destroy(newShooting, 1f);
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

    private void FixedUpdate()
    {
        if (ammo == 0)
        {
            ammoImage1.enabled = true;
            ammoImage2.enabled = false;
            ammoImage3.enabled = false;
        }
        else if (ammo == 1)
        {
            ammoImage1.enabled = false;
            ammoImage2.enabled = true;
            ammoImage3.enabled = false;
        }
        else if (ammo == 2)
        {
            ammoImage1.enabled = false;
            ammoImage2.enabled = false;
            ammoImage3.enabled = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Death"))
        {
            
            int randomSound = Random.Range(0, dyingSounds.Length);
            _audioSource.PlayOneShot(dyingSounds[randomSound]);
            
            _animator.Play("Jim_Death");
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
