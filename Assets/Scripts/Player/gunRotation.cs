using UnityEngine;

public class gunRotation : MonoBehaviour
{
    public Aim aim;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, -aim.Direction);
    }
}
