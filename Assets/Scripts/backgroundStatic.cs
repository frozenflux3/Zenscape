using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundStatic : MonoBehaviour
{
    // Start is called before the first frame update
    public float backgroundOffset=0;
    public float backgroundOffsety=0;

    void Start()
    {
        // backgroundOffset=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player")){

        transform.position=new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x-backgroundOffset,backgroundOffsety,transform.position.z);
        }
        
    }
}
