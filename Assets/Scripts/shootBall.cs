using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBall : MonoBehaviour
{
    // public float LaunchForce; removed because we are using force from cannon script

    public GameObject Ball;
    public GameObject Cannon;
    public GameObject[] landsStart;
    public GameObject landsTempStart;
    public static bool ShootOnTouchLeave=false;
    public int stockrange;
    private bool hasshot;
    float x;
    float y;
    
    // Start is called before the first frame update
    void Start()
    {   
        hasshot=false;
        ShootOnTouchLeave=false;

    }

    // Update is called once per frame
    void Update()
    {
        landsStart= GameObject.FindGameObjectsWithTag("LandStart");
        landsTempStart=landsStart[0];
        // if(gamemanager.rangegeneration==false){
        //        generate();
        // }
        if(Input.GetKeyDown(KeyCode.Space) && !gamemanager.hasShot && gameObject.tag=="Cannon" || ShootOnTouchLeave && !gamemanager.hasShot  && gameObject.tag=="Cannon")
        {   if(!hasshot){
            Shoot(); 
            gamemanager.hasShot=true; 
            ShootOnTouchLeave=false;
            hasshot=true;
        }
           
        }

        // if(Input.GetKeyDown(KeyCode.KeypadEnter) && gamemanager.hasShot && !gamemanager.Oncannon)
        // {   
        //    GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity=new Vector2(0.85f,0.5f) * 20;
        // }
    }

 

    void Shoot()
    {
        try{
        FindObjectOfType<AudioManager>().SFXPlay("CannonShot");
        }
        catch{
            
        }
        Destroy(GameObject.FindWithTag("Player"));
        gameObject.tag="usedCannon";
        gamemanager.coincord = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
       // Debug.Log(gamemanager.coincord);
        cameraFollow.changeCamera=true;
        gamemanager.Oncannon=false;
        // GameObject BallIns=Instantiate(Ball,new Vector3(transform.position.x+2,transform.position.y+2,transform.position.z),Quaternion.Euler(0, 0, 0));
        GameObject BallIns=Instantiate(Ball,new Vector3(transform.position.x+5,transform.position.y+2,1),Quaternion.Euler(0, 0, 0));//hv1
        BallIns.GetComponent<Rigidbody2D>().velocity=transform.right * cannonScript.force;//this part is speed multiplying the launchForce by transform right

       
        for(int i=0; i<=15; i++){
            Destroy(cannonScript.Points[i]);
        }
        
    }

}