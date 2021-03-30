using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerControls : MonoBehaviour
{


    public int tapCount;
    private float timePressed = 0.0f;
    public static float Dragspeed;

    private float totaltime = 0.0f;
    public GameObject ParachuteDeploy;
     Animator animator;
     public static bool hasopenedpara;
     private float main_time;
    public  float click_time;
    private float bool_time=0.2f;
    private float two_click_time;
    private int count;
    private float two_twoClicks;
    private float time;
    public bool doubleTap;


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
   

        if(gamemanager.hasShot ){
            TouchLogic();

        }
        dragforfive();
    }



    void TouchLogic(){
if (Input.GetMouseButton(0)){
   if (main_time == 0.0f){
      main_time = Time.time;
   }
   if (Time.time - main_time > bool_time && !hasopenedpara) {
       //Long press the action performed here
            Debug.Log("Long click");
            animator =  GameObject.FindWithTag("Player").GetComponent<Animator>();
            FindObjectOfType<AudioManager>().SFXPlay("character_parachute");
            hasopenedpara=true;
            animator.SetBool("ParachuteAnimationTrigger", true);
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
            Dragspeed=2f;

   }
}
if (Input.GetMouseButtonUp(0))
        {
            if (Time.time - main_time < bool_time)
            {//When the mouse is raised, the time from pressing to lifting is detected. If it is less than 2.0f, it is judged as a click.
            
                if (two_twoClicks != 0 && Time.time - two_twoClicks < bool_time)
                {
                    count = 2;
                }
                else
                {
                    count++;
                    if (count == 1)
                    {
                        time = Time.time;
                    }
                }
                if (count == 2 && !doubleTap
                    && ((time != 0 && Time.time - time < bool_time) || (two_twoClicks != 0 && Time.time - two_twoClicks < bool_time)))
                {//If the double click event is less than 0.2f, it is judged as a double click
                //Code block executed when double click
                    count = 0;
                    Debug.Log("Double click");
           GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
           doubleTap=true;
            StartCoroutine(Countdown());

                }               
                if (count == 2 && (Time.time - time > bool_time || Time.time-two_twoClicks > bool_time))
                {
                    two_twoClicks = Time.time;
                    count = 0;
                }
                main_time = 0.0f;
            }
            else
            {
                main_time = 0.0f;
            }
      }
            
            

    }


     
     
          private IEnumerator Countdown()
     { 
            
             yield return new WaitForSeconds(0.8f);
            doubleTap=false;
     }
     
     
     public void dragforfive(){
            if(Dragspeed<4){
                Dragspeed += Time.deltaTime;
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().drag = Dragspeed;
                GameObject.FindWithTag("Player").transform.rotation = Quaternion.Euler(0, 0, 0);
            }
     }
}
