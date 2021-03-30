using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuButtons : MonoBehaviour
{
     public static string[] sceneNames = {"Theme1","Theme2","Theme3","Theme4","Theme5","Theme6"};
    public static string[]    bgMusicNames = {"BackgroundMusic1","BackgroundMusic2","BackgroundMusic3","BackgroundMusic4","BackgroundMusic5","BackgroundMusic6"};
    int[] sceneCost = {0,0,0,0,0,0};
    
    public bool[] sceneOwned=new bool[8];
    public bool[] trialremaining=new bool[6];
    int[] freetrial = {0,2,2,2,2,2};
    public static int SceneIndex=0;
    public GameObject MenuCloseButton;
    public GameObject MenuOpenButton;
    public GameObject MenuPanel;
    public Slider volumeSlider;
    public Slider SFXSlider;

    public GameObject[] HideforSettings;
    public TextMeshProUGUI  startText;
    public static int coins;
    public GameObject Lock;
    public GameObject rain;
    public int tutorialcheck;


    // Start is called before the first frame update
    void Start()
    {   
        tutorialcheck = PlayerPrefs.GetInt("tutorial",0);
        FindObjectOfType<AudioManager>().Play(bgMusicNames[Mathf.RoundToInt((PlayerPrefs.GetFloat("CurrentScene",0)*100)/20)]);
        volumeSlider.value = AudioManager.volume;
        SFXSlider.value = AudioManager.SFXvolume;
        sceneOwned[0]=true;
        for(int i=1;i<sceneNames.Length;i++){
            try{
            if(PlayerPrefs.GetInt(sceneNames[i],0)==1){
                sceneOwned[i]=true;
            }
            else{
                sceneOwned[i]=false;

            }
            if(PlayerPrefs.GetInt(sceneNames[i]+"trial",2)>0){
                trialremaining[i]=true;
            }
            else{
                trialremaining[i]=false;

            }
            }
            catch{
            }
            freetrial[i]= PlayerPrefs.GetInt(sceneNames[i]+"trial",2);
        }
        coins=PlayerPrefs.GetInt("coins",0);

    
    }

    // Update is called once per frame
    void Update()
    {
        SceneIndex=Mathf.RoundToInt((SwipeMenu.scroll_pos*100)/20);
        // Debug.Log(SceneIndex);

        if(sceneOwned[SceneIndex]){
   
            startText.text="Tap To Start";
            Lock.SetActive(false);

        }
        else if(trialremaining[SceneIndex]){
            startText.text=freetrial[SceneIndex] + " Free Trials Remaining  ";
            Lock.SetActive(false);

        }
        else{
            startText.text="Buy Now for "+sceneCost[SceneIndex];
                       Lock.SetActive(true);
        }
        
        // else{
        //     freetrialparent.SetActive(false);
        // }
        

    }
      public void credits(){
        SceneManager.LoadScene("Credits");
    }
    public void tutorial(){
        SceneManager.LoadScene("Tutorials");
    }
    public void BacktoMenu(){
        SceneManager.LoadScene("SwipeMenu");
    }
    public void Settings(){
        SceneManager.LoadScene("Settings");
    }
     public void RestartGame(){
        SceneIndex=Mathf.RoundToInt((SwipeMenu.scroll_pos*100)/20);
        if(tutorialcheck==0){
            PlayerPrefs.SetInt("tutorial",1);
            SceneManager.LoadScene("Tutorials");
        }
        else if(sceneOwned[SceneIndex]){
        SceneManager.LoadScene(sceneNames[SceneIndex]);
        }
        else{
           BuyTheme();
        }
    }
    public void NextButton(){
        if(SwipeMenu.scroll_pos<1f && SceneIndex<5){
            FindObjectOfType<AudioManager>().SFXPlay("swipe");
            try{
                
            FindObjectOfType<AudioManager>().Stop(bgMusicNames[SceneIndex]);
            }
            catch{

            }
                try{

            FindObjectOfType<AudioManager>().Play(bgMusicNames[SceneIndex+1]);
            }
            catch{
                
            }

            SwipeMenu.scroll_pos += 0.20f;
            
           
        }
    }
    
    public void PrevButton(){
        if(SwipeMenu.scroll_pos>0f && SceneIndex>0){
           
            FindObjectOfType<AudioManager>().SFXPlay("swipe");
                                try{
            FindObjectOfType<AudioManager>().Play(bgMusicNames[SceneIndex-1]);
                    }
            catch{

            }
  

            FindObjectOfType<AudioManager>().Stop(bgMusicNames[SceneIndex]);

             SwipeMenu.scroll_pos -= 0.20f;
        }
    }
    public void MenuClose(){
        MenuPanel.SetActive(false);
        foreach (GameObject item in HideforSettings)
        {
            item.SetActive(true);
        }

    }
     public void MenuOpen(){
        MenuPanel.SetActive(true);
         foreach (GameObject item in HideforSettings)
        {
            item.SetActive(false);
        }

    }

    public void SetMusicVolume(float volume){
        AudioManager.newvolume = volume;
    }
    public void SetSFXVolume(float volume){
        AudioManager.SFXnewvolume = volume;
    }
    public void BuyTheme(){
        if(freetrial[SceneIndex]>0){
            freetrial[SceneIndex] -= 1;
            PlayerPrefs.SetInt(sceneNames[SceneIndex]+"trial", freetrial[SceneIndex]);
            SceneManager.LoadScene(sceneNames[SceneIndex]); 
        }
        else if(coins>=sceneCost[SceneIndex])
        {
        FindObjectOfType<AudioManager>().SFXPlay("unlock");
        SceneIndex=Mathf.RoundToInt((SwipeMenu.scroll_pos*100)/20);
        sceneOwned[SceneIndex]=true;
        coins-=sceneCost[SceneIndex];
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt(sceneNames[SceneIndex], 1);

        }
        else{
            ThemesUnlock.timeLeft=3.0f;
        }   
    }

    // public void UseFreetrial(){
    //     if(freetrial[SceneIndex]>0){
    //         freetrial[SceneIndex] -= 1;
    //         PlayerPrefs.SetInt(sceneNames[SceneIndex]+"trial", freetrial[SceneIndex]);
    //         SceneManager.LoadScene(sceneNames[SceneIndex]); 
    //     }
    // }
}
