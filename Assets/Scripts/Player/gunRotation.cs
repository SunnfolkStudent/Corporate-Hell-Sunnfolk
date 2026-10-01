using UnityEngine;

public class gunRotation : MonoBehaviour
{
    public Aim aim;

    private void Update()
    {
        if (PauseManager.paused) return;
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, -aim.Direction);
    }
}
