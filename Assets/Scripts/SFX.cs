
// using UnityEngine;
// using UnityEngine.Audio;
// using System;

// public class SFX : MonoBehaviour
// {
//     public Sound[] SFXsounds;
//     public static AudioManager SFXinstance;
//     public static float SFXvolume;
//     public static float SFXnewvolume;

//     // Start is called before the first frame update
//     void Awake()
//     {
//         if(SFXinstance == null)
//             SFXinstance=this;
//         else{
//             Destroy(gameObject);
//             return;
//         }    
//         DontDestroyOnLoad(gameObject);
//         foreach (Sound sound in SFXsounds)
//         {
//             sound.Source = gameObject.AddComponent<AudioSource>();
//             sound.Source.clip = sound.clip;
//             sound.Source.volume =  PlayerPrefs.GetFloat("musicvolume", 0);
//             SFXvolume=sound.Source.volume;
//             sound.Source.pitch = sound.pitch;
//             sound.Source.loop = sound.loop;
//         }
//     }
    
//     void Start(){
//         //  DontDestroyOnLoad(gameObject);
//         //         foreach (Sound sound in SFXsounds)
//         // {
//         //     sound.Source = gameObject.AddComponent<AudioSource>();
//         //     sound.Source.clip = sound.clip;
//         //     sound.Source.volume =  PlayerPrefs.GetFloat("musicvolume", 0);
//         //     SFXvolume=sound.Source.volume;
//         //     sound.Source.pitch = sound.pitch;
//         //     sound.Source.loop = sound.loop;
//         // }
//     }

//     public void Play(string name){
//         Sound s = Array.Find(SFXsounds, sound => sound.name == name);
//         s.Source.Play();
//     }

//     void Update(){
//         if(SFXnewvolume>0){
//             SFXvolume=SFXnewvolume;
//                 foreach (Sound sound in SFXsounds)
//         {
//             sound.Source.volume = SFXnewvolume;
//             PlayerPrefs.SetFloat("musicvolume", SFXnewvolume);
//         }
//         SFXnewvolume=0;
//         }

//         // if(stopmusic){
//         //     foreach (Sound sound in SFXsounds)
//         // {
//         //     sound.Source.volume = 0;
//         //      PlayerPrefs.SetFloat("musicvolume", 0);
//         // }
//         // }
//         // else{
//         //     foreach (Sound sound in SFXsounds)
//         // {
//         //     sound.Source.volume = volume;
//         //      PlayerPrefs.SetFloat("musicvolume", volume);
//         // }
//         // }
//     }
     
// }
