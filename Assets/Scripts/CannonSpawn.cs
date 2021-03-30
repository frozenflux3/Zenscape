using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;


public class CannonSpawn : MonoBehaviour
{
    public static float [,] spawngrid = new float[7,2] { {221.36f,4.27f}, {352.17f,-5.93f}, {-20.98f,-5.54f}, {10.74f,-5.41f} ,{80.59f,-1.91f}, {136.54f,-4.83f},{194.55f,-5.07f}};   
    public GameObject Cannon;
    int range;
    int noofcannons;
    int lengthofarray;

    // Start is called before the first frame update
    void Start()
    {
        
            // noofcannons=Random.Range(2,5);
            // lengthofarray=spawngrid.Length/2;
            // for(int i=0;i<noofcannons;i++){

            //  range = Random.Range(0,100);
           
            // // try{
            // //     if(GameObject.FindWithTag("unusedCannon").transform.position.x)
            // // }
            // Instantiate(Cannon,new Vector3(spawngrid[range%lengthofarray,0]+transform.position.x-447,spawngrid[range%lengthofarray,1],0),Quaternion.identity);
            // for(int j=range%lengthofarray;j<lengthofarray-1;j++){
            //     spawngrid[j,0]=spawngrid[j+1,0];
            //     spawngrid[j,1]=spawngrid[j+1,1];
            // }
            // //  Array.Resize(ref spawngrid, spawngrid.Length - 1);
            // lengthofarray-=1;
            // }
            for(int i=0;i<7;i++){
            Instantiate(Cannon,new Vector3(spawngrid[i,0]+transform.position.x,spawngrid[i,1],0),Quaternion.identity);
            }

    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
