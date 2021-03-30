using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public static bool Ispaused=false;
    public GameObject PausePanel;
    public GameObject pauseButton;
    public static GameObject pauseButtoncopy;
    void Start(){
        pauseButtoncopy=pauseButton;
        Ispaused=false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Timer.timerRunning || Ispaused){
             pauseButton.SetActive(false);
        }
        else {
          pauseButton.SetActive(true);
        }
    }
    public void resume(){
        FindObjectOfType<AudioManager>().SFXStop("PausePlayer");
        pauseButton.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        Ispaused=false;
    }
   
    public void Newpause(){
        FindObjectOfType<AudioManager>().SFXPlay("PausePlayer");
        pauseButton.SetActive(false);
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        Ispaused=true;
    }
    public void restart(){
                FindObjectOfType<AudioManager>().SFXStop("PausePlayer");

        SceneManager.LoadScene(gamemanager.currentScene);
    }

    // public void StopMusic(){
    //     if(AudioManager.stopmusic){
    //         AudioManager.stopmusic=false;
    //     }
    //     else
    //     {
    //         AudioManager.stopmusic=true;
    //     }
    // }
}
