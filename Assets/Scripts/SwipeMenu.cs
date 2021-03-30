using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollbar;
    public static float scroll_pos;
    float[] pos;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI coins;
    public float prevPos;
    
    // Start is called before the first frame update
    void Start()
    {

        scroll_pos = PlayerPrefs.GetFloat("CurrentScene",0);
        prevPos=MenuButtons.SceneIndex;


    }

    // Update is called once per frame
    void Update()
    {
        HighScore.text="HighScore:"+Mathf.Floor(PlayerPrefs.GetFloat("score",0)).ToString()+"m";
        coins.text=MenuButtons.coins.ToString();
        
        pos = new float[transform.childCount];
        float distance = 1f/ (pos.Length - 1f);
        // Debug.Log(distance);
        for(int i = 0; i< pos.Length; i++){
            pos[i]= distance * i;
        }
        if(Input.GetMouseButton (0)){
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else{
            for(int i = 0; i< pos.Length; i++){
                if(scroll_pos < pos[i] + (distance/2) && scroll_pos > pos[i] - (distance/2)){
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.5f);
                }
        }
        }

        for(int i = 0; i< pos.Length; i++){
                if(scroll_pos < pos[i] + (distance/2) && scroll_pos > pos[i] - (distance/2)){
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f,1f), 0.1f);
                     for(int a = 0; a< pos.Length; a++){
                        if(a!= i){
                            transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f,0.8f), 0.1f);

                        }
                     }
                }
        }
        if(prevPos!= MenuButtons.SceneIndex){
            FindObjectOfType<AudioManager>().SFXPlay("swipe");

                try{

            FindObjectOfType<AudioManager>().Stop(MenuButtons.bgMusicNames[MenuButtons.SceneIndex-1]);
            }
            catch{
                
            }

            try{

            FindObjectOfType<AudioManager>().Stop(MenuButtons.bgMusicNames[MenuButtons.SceneIndex+1]);
            }
            catch{
                
            }
                try{

            FindObjectOfType<AudioManager>().Play(MenuButtons.bgMusicNames[MenuButtons.SceneIndex]);
            }
            catch{
                
            }
            PlayerPrefs.SetFloat("CurrentScene",scroll_pos);
            ThemesUnlock.timeLeft=0f;
            prevPos=MenuButtons.SceneIndex;
        }
    }
}
