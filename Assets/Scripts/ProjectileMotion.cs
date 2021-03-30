using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;
public class ProjectileMotion : MonoBehaviour
{   
    Rigidbody2D rb; 
    public float maxSpeed = 1000f;
    public static bool spawnInvoke= true;
    public GameObject[] CannonList;
    public static GameObject[] statCannonList;


    // Start is called before the first frame update
    void Start()
    {
        PlayerControls.hasopenedpara=false;
        spawnInvoke= true;
        rb = GetComponent<Rigidbody2D>();
        statCannonList=CannonList;
    }

    // Update is called once per frame
    void Update()
    {   
        
            trackMovement(); 
        if(transform.position.y<-20f){
            gamemanager.endtime=0f;
            Destroy(gameObject);
        }   
  
         
    }

    void trackMovement()
    {
        Vector2 direction = rb.velocity;

        float angle = Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);//applying the angle we calculated int the above step

    }


    void OnCollisionEnter2D(Collision2D col) {//i

        CannonList = GameObject.FindGameObjectsWithTag("Cannon");

         if (col.gameObject.tag == "unusedCannon")
         { 
            col.gameObject.tag="Cannon";
            cameraFollow.changeCamera=false;
            Destroy(gameObject);
            gamemanager.hasShot=false;
            gamemanager.Oncannon=true;
            gamemanager.rangegeneration =false;
            gamemanager.coinspawned=false;
            gamemanager.endtime=20.0f;
            gamemanager.haspassed=false;
            gamemanager.endslidercopy.value=gamemanager.endslidercopy.maxValue;
            newSlider.TempCanonIndex=0;
            Timer.timeLeft=2.5f;
            Timer.startByCannon=true;
            PlayerControls.Dragspeed=5.0f;
         }
         else if(col.gameObject.tag == "Coins"){

             Destroy(col.gameObject);         
         }
         else if(col.gameObject.tag == "Obstacle"){
            gamemanager.endtime=0.5f;
         }
         else{
             spawnInvoke=false;
             gamemanager.distance=transform.position.x-gamemanager.distance;
         }
    }
}
