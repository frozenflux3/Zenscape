using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        // rb = this.GetComponent<Rigidbody2D>();
        // rb.velocity = new Vector2(-10,0);
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        try{
        if(transform.position.x+100<GameObject.FindGameObjectWithTag("Player").transform.position.x){
            // Debug.Log("asf");
            Destroy(gameObject);
        }
        }
        catch{

        }
    }
}
