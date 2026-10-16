using UnityEngine;
using UnityEngine.InputSystem;
public partial class CloseSoundBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
public GameObject AudioSettings;

    // Update is called once per frame
    void Update()

    {



        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            AudioSettings.SetActive(false);
        }
        


    }

    
}
