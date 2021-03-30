using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    Animator animator;
    public GameObject coin;
    public TextMeshProUGUI  ControlText;
    public TextMeshProUGUI  InfoText;
    public GameObject  SliderInfo;
    public static float timeraftershoot;
    public static bool goahead;
    public GameObject JumpButton;
    public int jumpcount;
    public GameObject Obstacle;
    public int jumptocollect;
    public float cointimer;
    public bool afterdodge;
    public bool aftercollect;
    public int fourjumps;
    public float endtime;
    public GameObject shoottext;
    public GameObject fakeslider;
    public GameObject fakedist;
    public int StringIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        endtime=0f;
        fourjumps=0;
        aftercollect=false;
        afterdodge=false;
        cointimer=0f;
        jumptocollect=0;
        jumpcount=0;
        timeraftershoot=2.0f;
        Time.timeScale = 1f;
        JumpButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if(gamemanager.hasShot){
            shoottext.SetActive(false);
            stopaftershoot();
        }

        jumpcount2();
        if(afterdodge){
        coincollect();
        }

        jumpcoincount2();

        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player")){
            SceneManager.LoadScene("Tutorials");
        }
    }

    public void stopaftershoot(){
        if(timeraftershoot>0){
            timeraftershoot -= Time.deltaTime;
        }
        else{
            Instantiate(Obstacle,GameObject.FindWithTag("Player").transform.position + new Vector3( 5,0,0),Quaternion.identity);
            fakeslider.SetActive(true);
            SliderInfo.SetActive(true);
            if(StringIndex==0){

            textTypingAnimation2.textToAnimate="";
            textTypingAnimation2.startC=true;
            textTypingAnimation2.textToAnimate = "You can either be killed by obstacle or if your lifebar depletes completely";
            StringIndex+=1;
            }
            JumpButton.SetActive(true);
            gamemanager.hasShot=false;
            Time.timeScale = 0f;

        }
    }

    public void jumpbuttoncounter(){
        jumpcount +=1;
    }

    public void jumpcount2(){
        if(jumpcount==2 && !afterdodge){
        jumpcount=0;
        fakeslider.SetActive(false);
        SliderInfo.SetActive(false);
        JumpButton.SetActive(false);
        Time.timeScale = 1f;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
        cointimer=1.0f;
        afterdodge=true;
        }
    }

    public void coincollect(){
        if(cointimer>0){
            cointimer -= Time.deltaTime;
        }
        else{
            for(int i=0;i<8;i++){
             Instantiate(coin,GameObject.FindWithTag("Player").transform.position + new Vector3( 5+i*4,1,0),Quaternion.identity);
             }
            ControlText.text = "Double Tap to Move Forward";
            JumpButton.SetActive(true);
          if(StringIndex==1){
              StringIndex+=1;
            textTypingAnimation2.textToAnimate="";
            textTypingAnimation2.startC=true;
            textTypingAnimation2.textToAnimate = "You can collect coins to buy themes";
          }
            // InfoText.text = "You can collect coins to buy themes";
            SliderInfo.SetActive(true);
            Time.timeScale=0f;
            cointimer=10000.0f;
        }
    }

    public void jumpcoincounter(){
        if(afterdodge){
        jumptocollect +=1;
        }
    }
    public void jumpcoincount2(){
        
        try{
        if(jumptocollect==2 && fourjumps<5){
            jumptocollect = 0;
            fourjumps += 1;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
        Time.timeScale = 1f;
        }
        if(GameObject.FindWithTag("Player").transform.position.x+5>GameObject.FindWithTag("unusedCannon").transform.position.x && !aftercollect){
            aftercollect=true;
            SliderInfo.SetActive(true);
            fakedist.SetActive(true);
                      if(StringIndex==2){
              StringIndex+=1;
            textTypingAnimation2.textToAnimate="";
            textTypingAnimation2.startC=true;
            textTypingAnimation2.textToAnimate = "Keep an eye on the Distance so you don't miss the next cannon.Your Lifebar gets refilled there";
          }

            // InfoText.text = "Keep an eye on the Distance so you don't miss out on the cannon";
            ControlText.text = "Press and Hold To Open Parachute";
            Time.timeScale = 0f;
        }
        }
        catch{
            fakedist.SetActive(false);
            SliderInfo.SetActive(false);
            ControlText.text = "ENJOY!!!";
            Invoke("loadscene",3f);
        }
        
    }

    public void openparachute(){
        if(aftercollect){
            Time.timeScale=1f;
            animator =  GameObject.FindWithTag("Player").GetComponent<Animator>();
            try{
            FindObjectOfType<AudioManager>().SFXPlay("character_parachute");
            }
            catch{
            }
             animator.SetBool("ParachuteAnimationTrigger", true);
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
             GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().drag = 4f;
        }
    }

public void loadscene(){
                SceneManager.LoadScene("SwipeMenu");

}

}
