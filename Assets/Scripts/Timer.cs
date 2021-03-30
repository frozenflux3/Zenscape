using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float timeLeft;
    public static bool timerRunning;

    public TextMeshProUGUI  timeText;
    public GameObject timerSliderFull;
   public static GameObject timerSliderFullcopy;
   public static bool startByCannon;
   public GameObject[] HideonStart;
    // Start is called before the first frame update
    void Start()
    {
      timerSliderFullcopy=timerSliderFull;
      timerRunning=true;
      timeLeft=4.0f;
      startByCannon=false;
    }

    // Update is called once per frame
    void Update()
     {
        gamestart();

     }

     public void gamestart(){
         if(timeLeft >1)
         {
            foreach (GameObject item in HideonStart)
            {
                item.SetActive(false);
            }
            Time.timeScale = 1f;
            timeLeft -= Time.deltaTime;
            // LoadingBar.fillAmount =timeLeft/10;
            timeText.text=Mathf.Floor(timeLeft).ToString("#");
            timerRunning=true;


         }
         else{
            timerRunning=false;
            timeText.text="";
            startByCannon=false;
            gamemanager.visibletime=2.0f;
            foreach (GameObject item in HideonStart)
            {
                item.SetActive(true);
            }

         }
         if(startByCannon){

        timerSliderFull.SetActive(false);
         }
         else if(!startByCannon && timerRunning){
        timerSliderFull.SetActive(true);

         }
         else{
        timerSliderFull.SetActive(false);

         }
      // Debug.Log(timeLeft);
     }
}
