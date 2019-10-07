using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixLevel : MonoBehaviour {


    public AudioMixer mixer;

   public  void MusicVol(float lvl)
    {
        mixer.SetFloat("musicVol", lvl);
    }
    public void SfxVol(float lvl)
    {
        mixer.SetFloat("sfxVolume", lvl);
    }
	
}
