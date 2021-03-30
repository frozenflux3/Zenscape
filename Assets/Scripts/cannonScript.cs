using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class cannonScript : MonoBehaviour
{    private Vector3 touchPosition;
    public Vector2 MousePos;
    public Vector2 direction;

    public static float force;//this is used but dotnt remember where lol
    public float mforce;//this is used but dotnt remember where lol
    public GameObject PointPrefab;
    public GameObject PointPrefabLight;
    public bool HasPointsSpawned;
    public static GameObject[] Points;
    

    public int numberOfpoints;  


    // Start is called before the first frame update
    void Start()
    {
        HasPointsSpawned=false;
    //    gamemanager.cannonCount+=1;

    }

    // Update is called once per frame
    void Update()
    {
        try{
        if(transform.position.x+10<GameObject.FindWithTag("Player").transform.position.x){
            gameObject.tag="usedCannon";
        }
        }
        catch{
            
        }

        if(!gamemanager.hasShot){

   DestroyCannon();
        }
 if(direction[1]>12 ){
         //   Debug.Log("above y");
            direction[1]=12f;
        }
        if(direction[0]<0){
          //  Debug.Log("less 7.5");
            direction[0]=7.5f;
        }
        if(direction[1]<0){
             //           Debug.Log("below y");

            direction[1]=0f;
        }
        

        if(!Timer.timerRunning && gameObject.tag=="Cannon"){
            oldUpdate();
                    if(!HasPointsSpawned){
                    HasPointsSpawned=true;
                    Points=new GameObject[numberOfpoints];

            for(int i=0; i<numberOfpoints; i++)
            {
                if(i<=numberOfpoints/2){
                Points[i] = Instantiate(PointPrefab,transform.position,Quaternion.identity);
                }
                else{
                Points[i] = Instantiate(PointPrefabLight,transform.position,Quaternion.identity);
                }  
            }
            

            }
        }



    }
    void oldUpdate(){
                  if (Input.touchCount > 0 && !shootBall.ShootOnTouchLeave)
        {
        Touch touch = Input.GetTouch(0);
        touchPosition=Camera.main.ScreenToWorldPoint(touch.position);
         MousePos =new Vector2(touchPosition[0],touchPosition[1]);
        
        if(touch.phase==TouchPhase.Ended ){
            shootBall.ShootOnTouchLeave=true;
        }
        
        }
        else{

         MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        force=(MousePos-(Vector2)transform.position)[0]*mforce; //calculate var force depend on pos

        Vector2 cannonPos = transform.position;
        direction = MousePos-cannonPos;
        if(direction[1]>14 ){
           // Debug.Log("above y");
            direction[1]=14f;
        }
        if(direction[0]<7.5f){
          //  Debug.Log("less 7.5");
            direction[0]=7.5f;
        }
        if(direction[1]<0){
           // Debug.Log("below y");
            direction[1]=0f;
        }
       // Debug.Log(direction);

        FaceMouse();
           
        
        // if(gamemanager.Oncannon && !gamemanager.hasShot){
        if(gameObject.tag=="Cannon"){

        try{
            for(int i=0;i<Points.Length;i++)
                {
                    Points[i].transform.position=PointPosition(i*0.07f);//7:53
                    
                    // Debug.Log(PointPosition(i*0.1f));
                }
        }
        catch{
            //Debug.Log("err");
        }
        }
    }
    void FaceMouse()
    {
        transform.right=direction;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos =(Vector2)transform.position + (direction.normalized * force * t) + 0.5f*Physics2D.gravity*(t*t);//P=p1+vel*t+at^2/2
        return currentPointPos;
    }
    void DestroyCannon(){
         try{
   if(transform.position.x+200<GameObject.FindWithTag("Player").transform.position.x){
    //    Destroy(gameObject);
   }
    }
    catch{
        
    }
    }
}
