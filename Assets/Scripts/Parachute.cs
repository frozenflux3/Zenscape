using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{   public int tapCount;
    private float timePressed = 0.0f;
public  float timeDelayThreshold = 1.0f;
    private float totaltime = 0.0f;

    public GameObject ParachuteDeploy;
    // Start is called before the first frame update
    void Start()
    {
        timePressed = 0.0f;
        timeDelayThreshold = 1.0f;
        totaltime = 0.0f;
    }

    // Update is called once per frame

      void Update()
     {

         
       


      // Debug.Log(Time.time);        //mobile
        if(Input.touchCount > 0 && gamemanager.hasShot){

        checkForLongPress(0.5f);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && gamemanager.hasShot)
         {
             tapCount += 1;
             StartCoroutine(Countdown());    
         }
       
         if (tapCount == 2 && gamemanager.hasShot)
         {    
             
             tapCount = 0;
             StopCoroutine(Countdown());
           GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
             
     
         }
        //  pc
        if(Input.GetKeyDown(KeyCode.P) && gamemanager.hasShot && !gamemanager.Oncannon)
        {   
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().drag = 5;
            ParachuteDeploy.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        }
        // both
        if(ParachuteDeploy){
            ParachuteDeploy.transform.rotation = Quaternion.Euler(0, 0, 0);
            ParachuteDeploy.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(0,1,0);
        }
         
 
     }



 

     private IEnumerator Countdown()
     { 
             yield return new WaitForSeconds(0.3f);
             tapCount = 0;  
     }
    void checkForLongPress(float tim) {
        if (Input.GetTouch(0).phase == TouchPhase.Began) { // If the user puts her finger on screen...
            timePressed = Time.time;//15 -> 20
        }
            totaltime = Time.time - timePressed;
            // timeLastPress = Time.time;
            if (totaltime>tim) { // Is the time pressed greater than our time delay threshold?
            //Do whatever you want
             Debug.Log("here"); 
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().drag = 5;
                ParachuteDeploy.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
                ParachuteDeploy.transform.rotation = Quaternion.Euler(0, 0, 0);
                ParachuteDeploy.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(0,1,-1);
            }
        if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) { // If the user puts her finger on screen...
            
        }
    }
}
