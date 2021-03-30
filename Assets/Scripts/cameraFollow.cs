using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

using Cinemachine;
public class cameraFollow : MonoBehaviour
{

 public CinemachineVirtualCamera m_OrthographicCamera;
    
  

    public float cameraSize=10f;
    // public GameObject moon;
    public static bool changeCamera=false;
    void Start()
    {
        cameraSize=10f;
changeCamera=false;

    }

    // Update is called once per frame
    void Update()
    {
        
         //   Debug.Log(Oncannon);

        
        if(changeCamera && cameraSize<20){

        m_OrthographicCamera.m_Lens.OrthographicSize = cameraSize;

        //  m_OrthographicCamera.orthographicSize = cameraSize;
         cameraSize += 10 * Time.deltaTime;
         transform.position+=new Vector3(0,5f*Time.deltaTime,0);
        //  moon.transform.position+=new Vector3(-8*Time.deltaTime,10*Time.deltaTime,0);
        }
        else if(!changeCamera && cameraSize>=10){
        m_OrthographicCamera.m_Lens.OrthographicSize = cameraSize;

        // m_OrthographicCamera.orthographicSize = cameraSize;
         cameraSize -= 10 * Time.deltaTime;
         transform.position-=new Vector3(0,5f*Time.deltaTime,0);
        //  moon.transform.position-=new Vector3(5*Time.deltaTime,5*Time.deltaTime,0);


        }
 



    }

    public static void ChangeChangeCamera(){
        if(changeCamera){
            changeCamera=false;
        }
        else{
            changeCamera=true;
        }
    }
}