using UnityEngine;

public class CutSceneAudio : MonoBehaviour
{

private AudioSource source;


private void Start()
{
	source = GetComponent<AudioSource>();

}
    public void PlaySpecificAudioCLip(AudioClip clip)
          {
	source.PlayOneShot(clip);
       }
}
