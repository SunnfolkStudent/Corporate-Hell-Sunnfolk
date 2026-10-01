using UnityEngine;

public class FloatEnemy : MonoBehaviour
{
    private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("Floater Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
