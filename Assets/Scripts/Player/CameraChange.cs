using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject CinemachineCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            CinemachineCamera.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            CinemachineCamera.SetActive(false);
        }
    }
}

