using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using Slider = UnityEngine.UI.Slider;
 
public class AudioManager : MonoBehaviour
{
   public AudioMixer masterMixer;
   //public Slider MasterVolSlider, SFXVolSlider, MusicVolSlider, DialogueVolSlider;
   public Slider[] MixerSliders;
 
   private void Start()
   {
      InitialiseSliders();
      InitialiseMixerVolume();
   }
 
   private void InitialiseMixerVolume()
   {
      for (int i = 0; i < MixerSliders.Length; i++)
      {
         masterMixer.SetFloat(MixerSliders[i].name, Mathf.Log10(PlayerPrefs.GetFloat(MixerSliders[i].name))*20);
      }
   }
 
   private void InitialiseSliders()
   {
      for (int i = 0; i < MixerSliders.Length; i++)
      {
         MixerSliders[i].value = PlayerPrefs.GetFloat(MixerSliders[i].name);
      }
   }
 
   private void Update()
   {
      if (Keyboard.current.oKey.wasPressedThisFrame)
      {
         for (int i = 0; i < MixerSliders.Length; i++)
         {
            print(MixerSliders[i].name+PlayerPrefs.GetFloat(MixerSliders[i].name));
         }
         /*print(PlayerPrefs.GetFloat("MasterVolume"));
         print(PlayerPrefs.GetFloat("SFXVolume"));
         print(PlayerPrefs.GetFloat("MusicVolume"));
         print(PlayerPrefs.GetFloat("DialogueVolume"));
         */
      }
   }
 
 
   public void ApplyChanges()
   {
      for (int i = 0; i < MixerSliders.Length; i++)
      {
         PlayerPrefs.SetFloat(MixerSliders[i].name, MixerSliders[i].value);
      }
      /*PlayerPrefs.SetFloat("MasterVolume", MasterVolSlider.value);
      PlayerPrefs.SetFloat("SFXVolume", SFXVolSlider.value);
      PlayerPrefs.SetFloat("MusicVolume", MusicVolSlider.value);
      PlayerPrefs.SetFloat("DialogueVolume", DialogueVolSlider.value);
      */
   }
 
   public void SetMasterVolume(float mastervol)
   {
      masterMixer.SetFloat("MasterVolume", Mathf.Log10(mastervol)*20); 
   }
 
   public void SetSFXVolume(float sfxvol)
   {
      masterMixer.SetFloat("SFXVolume", Mathf.Log10(sfxvol)*20);
   }
 
   public void SetMusicVolume(float musicvol)
   {
      masterMixer.SetFloat("MusicVolume", Mathf.Log10(musicvol)*20);
   }
 

}
