using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class gamemanager : MonoBehaviour
{
    public  static int cannonCount;
    public static Vector3 coinsTopRight=Vector3.zero;
    public GameObject coin;
    public GameObject Obstacles;
    public static bool coinspawned;
    public static int coins=0;
    public static Vector2 coincord;
    public int xrange;
    public int yrange;
    public static bool rangegeneration;
    public static int numberofcoins;
    public TextMeshProUGUI  CoinsText;
    public static int PlayerCoins;
    public static bool Oncannon;
    public static bool hasShot;
    public static float distance;
    public GameObject[] CannonList;
    public static float groundstart;
    public int numberofspawns;
    public static float endtime;
    public static bool haspassed;
    public Slider endslider; 
    public static Slider endslidercopy;
    public GameObject DeathPanel;
    public GameObject pauseButton;
    public GameObject staticCoin;
    public static float visibletime;
    public float score;
    public static int PrevPlayerCoins;
    public TextMeshProUGUI  DeathPanelPlayerScore;
    public TextMeshProUGUI  DeathPanelPlayerHighScore;
    public TextMeshProUGUI  DeathPanelCoinsCollected;
    public GameObject[] HideOnDeath;
    public static string currentScene;
    public  string currentSceneCopy;


    // Start is called before the first frame update
    void Start()
    {
    currentScene=currentSceneCopy;
    score=-34f;
    PlayerCoins=PlayerPrefs.GetInt("coins",0);
    PrevPlayerCoins=PlayerCoins;
    cannonCount=0;
    endslidercopy=endslider;
    endslidercopy.minValue=0f;
    endslidercopy.maxValue=20f;
    endslidercopy.value=20.0f;
    haspassed=false;
    endtime = 20.0f;
    groundstart=0;
    rangegeneration=false;
    coinspawned=false; 
    ProjectileMotion.spawnInvoke=true;
    coins = 0;
    distance= transform.position.x;
    Oncannon=true;
    hasShot=false;
    visibletime=0f;

    // FindObjectOfType<AudioManager>().Play("BackgroundMusic");
    }

    // Update is called once per frame
    void Update()
    {
       
        coinSpawnLogic();
        try{

        coinsTopRight= GameObject.FindGameObjectWithTag("CoinTemp").transform.position;
        CoinsText.text=PlayerCoins.ToString();
        }   
        catch{

        }
        
        if(hasShot){
        overjumped();
        }

        if(visibletime>0){
        visibletime -= Time.deltaTime;
        //Debug.Log(visibletime);
            staticCoin.SetActive(true);
        }
        else{
            staticCoin.SetActive(false);
        }



        
    }
    



    public void coinSpawnLogic(){
        if( !GameObject.FindWithTag("Player") && !coinspawned && currentSceneCopy!="Tutorials"){
        coinSpanwer();
        ObstacleSpanwer();
        coinspawned=true;
        }

       
    }
    public void ObstacleSpanwer(){
        numberofspawns= Random.Range(2,3);
        for(int a=0;a<numberofspawns;a++){
        xrange = Random.Range(70, Mathf.RoundToInt(GameObject.FindWithTag("Cannon").transform.position.x+250)-5);
        yrange = Random.Range(3, 12);
        // Debug.Log("spawn");
        Instantiate(Obstacles,new Vector3( GameObject.FindWithTag("Cannon").transform.position.x+xrange,yrange,0),Quaternion.identity);
        // Debug.Log("spawnend");
        
        }
    }


    public void coinSpanwer(){
        numberofspawns= 1;//Random.Range(2,8);
        for(int a=0;a<numberofspawns;a++){
        xrange = Random.Range(50, Mathf.RoundToInt(GameObject.FindWithTag("Cannon").transform.position.x+150)-5);
        yrange = Random.Range(3, 12);
        numberofcoins = Random.Range(8, 20);
        for(int i=0;i<numberofcoins;i++){
            //Debug.Log("here");
        Instantiate(coin,new Vector3( GameObject.FindWithTag("Cannon").transform.position.x+xrange+i*4,yrange,0),Quaternion.identity);
        }
        }
    }



    public void MainMenu(){
        try{
                FindObjectOfType<AudioManager>().SFXStop("PausePlayer");
        }
        catch{
            
        }
            Time.timeScale=1f;
             SceneManager.LoadScene("SwipeMenu");
    }
   
   public void overjumped(){
       
    endtime -= Time.deltaTime;
    endslidercopy.value = endtime;

try{
    if(endtime<0){
        
        foreach (GameObject item in HideOnDeath)
        {
            item.SetActive(false);
        }
        DeathPanel.SetActive(true);
        PlayerPrefs.SetInt("coins", PlayerCoins);
        // Debug.Log(PlayerCoins-PrevPlayerCoins);
        float tempHighScore=PlayerPrefs.GetFloat("score",0f);
         
        score = GameObject.FindWithTag("Player").transform.position.x - score;
       

        Destroy(GameObject.FindGameObjectWithTag("Player"));
        
        FindObjectOfType<AudioManager>().SFXPlay("Death");


        DeathPanelPlayerScore.text="You Have Soared "+Mathf.Floor(score).ToString()+"m";
        DeathPanelCoinsCollected.text=(PlayerCoins-PrevPlayerCoins).ToString()+" Coins Were Collected In This Run";
       
        if(score>tempHighScore){
           PlayerPrefs.SetFloat("score", score); 
        DeathPanelPlayerHighScore.text="Your Highscore Is "+Mathf.Floor(score).ToString()+"m";
        }
        else{
            DeathPanelPlayerHighScore.text="Your Highscore Is "+Mathf.Floor(tempHighScore).ToString()+"m";
        }




    }
}
catch{

}
   }
}
