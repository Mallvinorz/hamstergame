using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x + Input.GetAxis("Horizontal") * speed, this.transform.position.y, this.transform.position.z + Input.GetAxis("Vertical")*speed); 
        Debug.Log(Input.GetAxis("Horizontal")); 
    }
}
