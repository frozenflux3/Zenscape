using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemesUnlock : MonoBehaviour
{

    public GameObject Insufficient;
    public static float timeLeft;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InsufficientTimer();
    }


    public void InsufficientTimer(){
        if(timeLeft >1)
         {
            timeLeft -= Time.deltaTime;
            Insufficient.SetActive(true);

         }
         else{
            Insufficient.SetActive(false);
         }
    }
}
