using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerControlsCopy : MonoBehaviour
{


    public int tapCount;
    private float timePressed = 0.0f;
    public static float Dragspeed;

    private float totaltime = 0.0f;
    public GameObject ParachuteDeploy;
     Animator animator;
     bool hasopenedpara;
    // Start is called before the first frame update
    void Start()
    {
       timePressed = 0.0f;
        totaltime = 0.0f;
        Dragspeed=4f;
        hasopenedpara=false;
    }

    // Update is called once per frame
    void Update()
    {
   
                if((Input.touchCount > 0 &&     Timer.timerRunning) ){
            return;
        }
        if(gamemanager.hasShot  ){
            TouchLogic();
        }
        dragforfive();
    }



    void TouchLogic(){
        if(Input.touchCount > 0){

            checkForLongPress(0.5f);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
         {
             tapCount += 1;
             StartCoroutine(Countdown());    
         }
       
         if (tapCount == 2)//jump logic
         {    
             
             tapCount = 0;
             StopCoroutine(Countdown());
           GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
             
     
         }
        //  pc
        
        if(Input.GetKeyDown(KeyCode.KeypadEnter) )
        {   
           
            try{
           GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
            }
            catch{
                
            }
        }
        if(Input.GetKeyDown(KeyCode.P) )
        {   
                       animator =  GameObject.FindWithTag("Player").GetComponent<Animator>();
            FindObjectOfType<AudioManager>().SFXPlay("character_parachute");

             animator.SetBool("ParachuteAnimationTrigger", true);
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
          Dragspeed=2f;
        }

    }

    void checkForLongPress(float tim) {
        if (Input.GetTouch(0).phase == TouchPhase.Began) { // If the user puts her finger on screen...
            timePressed = Time.time;//15 -> 20
        }
            totaltime = Time.time - timePressed;
            if (totaltime>tim && !hasopenedpara) { // Is the time pressed greater than our time delay threshold?
            hasopenedpara=true;
            FindObjectOfType<AudioManager>().SFXPlay("character_parachute");
           GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;

           Dragspeed=2f;


            animator =  GameObject.FindWithTag("Player").GetComponent<Animator>();
             animator.SetBool("ParachuteAnimationTrigger", true);
            }
        if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) { // If the user puts her finger on screen...
            
        }
    }
     private IEnumerator Countdown()
     { 
             yield return new WaitForSeconds(0.3f);
             tapCount = 0;  
     }
     public void dragforfive(){
            if(Dragspeed<4){
                Dragspeed += Time.deltaTime;
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().drag = Dragspeed;
                GameObject.FindWithTag("Player").transform.rotation = Quaternion.Euler(0, 0, 0);
            }
     }
}
