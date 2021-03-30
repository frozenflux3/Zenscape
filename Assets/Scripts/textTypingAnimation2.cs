using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textTypingAnimation2 : MonoBehaviour
{
    // Start is called before the first frame update
    public static string textToAnimate="";
     int textToAnimateLenght;
     private int count=0;
     public TextMeshProUGUI  startText;
     string temp;
     string prevText="";
     public static bool startC=true;
    void Start()
    {
        //  StartCoroutine(Countdown());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startC){
            startC=false;
             count=0;
         StartCoroutine(Countdown());
            
        }

         textToAnimateLenght=textToAnimate.Length;
        temp="";
        for(int i=0;i<count;i++){
            try{

            temp+=textToAnimate[i];
            }
            catch{

            }
        }
  
        //         Debug.Log(textToAnimate.ToString());
        // Debug.Log(temp.ToString());
        // Debug.Log(count);
       
            startText.text=temp;
    }
    private IEnumerator Countdown()
     { 
             yield return new WaitForSecondsRealtime(0.03f);
            
                if(count<textToAnimateLenght){

        count += 1;  
             }


         StartCoroutine(Countdown());
            
     }
}
