using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textTypingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public string textToAnimate;
     int textToAnimateLenght;
    private int count=0;
     public TextMeshProUGUI  startText;
     string temp;
    void Start()
    {
        count=0;
         StartCoroutine(Countdown());
         textToAnimateLenght=textToAnimate.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        temp="";
        for(int i=0;i<count;i++){
            temp+=textToAnimate[i];
        }

            startText.text=temp;
    }
    private IEnumerator Countdown()
     { 
             yield return new WaitForSeconds(0.03f);
             count += 1;  
             if(count<textToAnimateLenght){

         StartCoroutine(Countdown());
             }

     }
}
