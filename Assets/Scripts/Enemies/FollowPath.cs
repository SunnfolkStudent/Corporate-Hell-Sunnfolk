using Unity.VisualScripting;
using UnityEngine;

public class FollowThePath : MonoBehaviour {

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;

    private int waypointIndex = 0;
    
    public bool shouldMove;

    public bool moveNOw;
    
    private Animator _animator;

    private void Start () {
        _animator = GetComponent<Animator>();
        _animator.Play("Chaser OFF");
        transform.position = waypoints[waypointIndex].transform.position;
    }

    public void SetMove()
    {
        moveNOw = true;
    }
 
    private void Update()
    {
        if (shouldMove)
        {
            _animator.Play("Chaser Turning On");
        }

        if (moveNOw)
        {
            Move();
        }
    }
    
    public void Move()
    {
        shouldMove = false;
        if (waypointIndex <= waypoints.Length - 1)
        {
            _animator.Play("Chaser ON");
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}