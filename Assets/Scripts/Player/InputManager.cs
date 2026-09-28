using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;
    
    public bool Gun;

    private void Update()
    {
        Gun = _inputSystem.Player.GUN.IsPressed();
    }

    private void Awake() { _inputSystem = new InputSystem_Actions(); }
    private void OnEnable() { _inputSystem.Enable(); }
    private void OnDisable() { _inputSystem.Disable(); }
}

