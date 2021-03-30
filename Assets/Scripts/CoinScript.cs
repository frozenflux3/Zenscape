using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
     public float smoothTime ;
    private Vector3 velocity = Vector3.zero;

    // public GameObject coinsValue;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {  
        CoinMotion();

        DestroyCoin();
        

    }

   void OnTriggerEnter2D(Collider2D col)
    {

    if(col.gameObject.CompareTag("Player")){
            gamemanager.coins+=1;
            smoothTime=100f;
            gamemanager.visibletime=5.0f;
            try{

            FindObjectOfType<AudioManager>().SFXPlay("Coins");
            }
            catch{
                
            }

        }
    }

    public void DestroyCoin(){
        if(GameObject.FindGameObjectWithTag("Player")){    
        if(transform.position.x+100<GameObject.FindGameObjectWithTag("Player").transform.position.x){
            Destroy(gameObject);
            }
        }
    }

    public void CoinMotion(){
        if(smoothTime>0 && gameObject.tag !="CoinTemp" ){
              //  Debug.Log("asdfa");

            // transform.position =Vector3.SmoothDamp(transform.position, gamemanager.coinsTopRight, ref velocity, smoothTime*Time.deltaTime);
            transform.position= Vector3.MoveTowards(transform.position,gamemanager.coinsTopRight, 70*Time.deltaTime);
            if(GameObject.FindGameObjectWithTag("CoinTemp").transform.position-transform.position== new Vector3(0,0,0)){
                gamemanager.PlayerCoins+=1;
            Destroy(gameObject);

            }
        }
    }
}
