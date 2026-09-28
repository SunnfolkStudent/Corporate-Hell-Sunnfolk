using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform crosshair;
    [SerializeField] private float aimRadius = 2f;
    
    public Vector2 Direction { get; private set; }

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Mouse.current == null)
            return;

        Vector3 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        
        Vector2 direction = mousePosition - transform.position;

        if (direction.sqrMagnitude < 0.001f)
            return;
        
        direction.Normalize();
        Direction = direction;
        
        crosshair.position = transform.position + (Vector3)(direction * aimRadius);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aimRadius);
    }
}
