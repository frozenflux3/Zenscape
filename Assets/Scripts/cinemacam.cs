using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;
public class cinemacam : MonoBehaviour
{
    public CinemachineVirtualCamera myCinemachine;
    public static CinemachineVirtualCamera myCinemachinecopy;
    public GameObject Ball;


    // Start is called before the first frame update
    void Start()
    {
        myCinemachinecopy=myCinemachine;
    }

    // Update is called once per frame
    void Update()
    {
        try{

        
        if( GameObject.FindWithTag("Player")){
        myCinemachine.m_Follow = GameObject.FindWithTag("Player").transform;
        }
        else{
        Instantiate(Ball,new Vector3(GameObject.FindWithTag("Cannon").transform.position.x+10,GameObject.FindWithTag("Cannon").transform.position.y+2,1),Quaternion.Euler(0, 0, 0));//hv1


         }
    }
    
    catch{

    }
    }
}
