using Unity.VisualScripting;
using UnityEngine;

public class FollowThePath : MonoBehaviour {

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;

    private int waypointIndex = 0;
    
    public bool shouldMove;

    private void Start () {

        transform.position = waypoints[waypointIndex].transform.position;
    }
 
    private void Update()
    {
        if (shouldMove)
        {
            Move();
        }
    }
    public void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {

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