using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;
    public float jumpForce = 0.2f;
    void Start()
    {
        
    }
    private void Update() {
        Debug.Log(Input.GetAxis("Jump")); 
        if(Input.GetAxis("Jump") == 1){
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }
    }
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x + Input.GetAxis("Horizontal") * speed, this.transform.position.y, this.transform.position.z + Input.GetAxis("Vertical")*speed); 
    }
}
