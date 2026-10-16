using System;
using UnityEngine;

public class FloatEnemy : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    
    public AudioClip dyingSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _animator.Play("Floater Idle");
    }

    public void deathSound()
    {
        _audioSource.PlayOneShot(dyingSound);
    }
}