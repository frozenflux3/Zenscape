
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] SFX;

    public static AudioManager instance;
    public static float volume;
    public static float newvolume;
     public static float SFXvolume;
    public static float SFXnewvolume;
    public static bool stopmusic;

    // Start is called before the first frame update
    void Awake()
    {
        stopmusic=false;
        if(instance == null)
            instance=this;
        else{
            Destroy(gameObject);
            return;
        }    
        DontDestroyOnLoad(gameObject);
        foreach (Sound sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.clip;
            sound.Source.volume =  PlayerPrefs.GetFloat("musicvolume", 1);
            volume=sound.Source.volume;
            sound.Source.pitch = sound.pitch;
            sound.Source.loop = sound.loop;
        }
        foreach (Sound sound in SFX)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.clip;
            sound.Source.volume =  PlayerPrefs.GetFloat("SFXvolume", 1);
            SFXvolume=sound.Source.volume;
            sound.Source.pitch = sound.pitch;
            sound.Source.loop = sound.loop;
        }
    }
    
    void Start(){
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.Source.Play();
    }
      public void SFXPlay(string name){
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.Source.Play();
    }
    
    public void SFXStop(string name){
        Sound s = Array.Find(SFX, sound => sound.name == name);
        s.Source.Stop();
    }
     
    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.Source.Stop();
    }


    void Update(){


        if(newvolume>0){
            volume=newvolume;
                foreach (Sound sound in sounds)
        {
            sound.Source.volume = newvolume;
            PlayerPrefs.SetFloat("musicvolume", newvolume);
        }
        newvolume=0;
        }
        if(SFXnewvolume>0){
            SFXvolume=SFXnewvolume;
                foreach (Sound sound in SFX)
        {
            sound.Source.volume = SFXnewvolume;
            PlayerPrefs.SetFloat("SFXvolume", SFXnewvolume);
        }
        SFXnewvolume=0;
        }

    }
     
}
