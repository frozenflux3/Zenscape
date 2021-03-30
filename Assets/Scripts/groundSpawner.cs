using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class groundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ground;
    public GameObject[] respawns;
    public GameObject groundNew;
    public static float groundz=365;
    bool first;
    public GameObject[] landsStart;
    public GameObject[] landsEnd;
    public GameObject[] landsCenter;
    public GameObject landsTempStart;
    public GameObject landsTempEnd;
    public GameObject landsTempCenter;
    public GameObject[] landPrefabs;

    void Start()
    {
        groundz=365;
        first = false;
    }

    // Update is called once per frame
    void Update()
    {
       landsStart= GameObject.FindGameObjectsWithTag("LandStart");
       landsEnd= GameObject.FindGameObjectsWithTag("LandEnd");
       landsCenter= GameObject.FindGameObjectsWithTag("LandCenter");
        landsTempStart=landsStart[landsStart.Length-1];
        landsTempEnd=landsEnd[landsEnd.Length-1];
        landsTempCenter=landsCenter[landsCenter.Length-1];


            if(landsCenter.Length<3){



                    if(!first){
                     fspawnGround();
                     first=true;
                    }
                    else{
                        spawnGround();

                    }

             }
            
                 

                
                        

    }
    void fspawnGround(){
        ground=landPrefabs[(Random.Range(0,100))%landPrefabs.Length];
        Instantiate(ground,new Vector3(landsTempEnd.transform.position.x+Mathf.Abs(landsTempCenter.transform.position.x)+Mathf.Abs(landsTempStart.transform.position.x),landsTempCenter.transform.position.y+0.03f,0),Quaternion.identity);
        groundz+=445.5f;        
    }
    void spawnGround(){
        ground=landPrefabs[Random.Range(0,100)%landPrefabs.Length];
        Instantiate(ground,new Vector3(landsTempEnd.transform.position.x+Mathf.Abs(landsTempCenter.transform.position.x)-Mathf.Abs(landsTempStart.transform.position.x)-1f,landsTempCenter.transform.position.y+0.03f,0),Quaternion.identity);
        groundz+=445.5f;
        
    }
}

