using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class newSlider : MonoBehaviour
{

    // public  Slider DistanceSlider;
    public  TextMeshProUGUI distance;   
    public static GameObject[] CannonList;
    public static int TempCanonIndex;
    public static float nextcannon;

    // Start is called before the first frame update
    void Start()
    {
        TempCanonIndex=0;
    }

    // Update is called once per frame
    void Update()
    {

        try{

        

                    nextcannon = GameObject.FindGameObjectWithTag("unusedCannon").transform.position.x;
        if(nextcannon-GameObject.FindWithTag("Player").transform.position.x<0){
            distance.text="0m";

        }else{

        distance.text=Mathf.Floor(nextcannon-GameObject.FindWithTag("Player").transform.position.x).ToString()+"m";
        }

    }

    
    catch{

    }
}
}
