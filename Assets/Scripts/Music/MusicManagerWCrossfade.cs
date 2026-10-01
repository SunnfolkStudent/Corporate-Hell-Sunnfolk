using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MusicManagerWCrossfade : MonoBehaviour
{
    public AudioSource audioSourceA;
    public AudioSource audioSourceB;
    
    public AudioClip intro;
    public float introLength;
    public AudioClip main;
    public float mainTime;
    public AudioClip chase;
    public float chaseTime;
    public UnityEvent onCollide;
    
    public PolygonCollider2D chaseCheck1;
    public PolygonCollider2D chaseDoneCheck1;
    public PolygonCollider2D chaseDoneCheck2;
    public PolygonCollider2D chaseCheck2;

    public bool canSwitchMusic;

    private IEnumerator Intro()
    {
        introLength = intro.length;
        audioSourceA.clip = intro;
        audioSourceA.Play();
        yield return new WaitForSeconds(introLength);
        audioSourceA.Stop();
        audioSourceA.clip = main;
        audioSourceA.Play();
    }
    private void Start()
    {
        StartCoroutine(nameof(Intro));
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        onCollide.Invoke();
    }
    
    private void Update()
    {
        
        if (chaseCheck1.IsTouchingLayers(LayerMask.GetMask("Player" )) || chaseCheck2.IsTouchingLayers(LayerMask.GetMask("Player" )))
        {
            mainTime = audioSourceA.time;
            audioSourceA.clip = chase;
            audioSourceA.Play();
            audioSourceA.time = mainTime;
        }
        
        if (chaseDoneCheck1.IsTouchingLayers(LayerMask.GetMask("Player" )) || chaseDoneCheck2.IsTouchingLayers(LayerMask.GetMask("Player" )))
        {
            chaseTime = audioSourceA.time;
            audioSourceA.clip = main;
            audioSourceA.Play();
            audioSourceA.time = chaseTime;
        }
    }
}