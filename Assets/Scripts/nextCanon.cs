using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

 using UnityEngine.UI;


public class nextCanon : MonoBehaviour
{
    public float speed=2f;
    public Image Arrow;
      public GameObject[] CannonList;
    // Start is called before the first frame update
    void Start()
    {
         speed=2f;
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);         
    pos.x = Mathf.Clamp01(pos.x);         
    pos.y = Mathf.Clamp01(pos.y);         
    transform.position = Camera.main.ViewportToWorldPoint(pos);  
        CannonList = GameObject.FindGameObjectsWithTag("Cannon");

        float step = speed * Time.deltaTime;
        try{
            if(CannonList.Length>1){
                Arrow.enabled=true;

         transform.position = Vector3.MoveTowards(transform.position, CannonList[CannonList.Length-1].transform.position, step);
            }
            else{
                Arrow.enabled=false;
            }
            // Debug.Log("asdf");

        }
        catch{

        }

    }
}
