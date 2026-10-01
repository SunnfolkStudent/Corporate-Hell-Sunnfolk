using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public FollowThePath followThePath;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            followThePath.shouldMove = true;
        }
    }
}
