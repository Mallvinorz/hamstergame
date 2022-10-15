using System.Collections;
//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public float jumpForce = 1f;
    public float rotationSpeed;
    public BoxCollider groundBox;

    Transform cameraTransform;
    Animator playerAnim;
    Vector3 movementDirection;
    
    float turnSmoothVelocity;
    bool isSitDown = false;

    void Start()
    {
        playerAnim = this.GetComponent<Animator>();
        isSitDown = playerAnim.GetBool("isSit");
        cameraTransform = Camera.main.transform;
    }
    private void Update() {
        // Debug.Log(Input.GetAxis("Jump"));
        if(Input.GetAxis("SitDown") == 1){
            if(isSitDown){
                StandUp();
            }else{
                SitDown();
            }
        } 

        if(isSitDown) return;

        Movement();

        if(Input.GetAxis("Jump") == 1) Jump();
        if(movementDirection != Vector3.zero) RotateMovement();
    }
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalMove, 0, verticalMove);//asign nilai input axis horizontal dan vertikal ke Vector3
        movementDirection.Normalize();//normalize nilai movementDirection agar nilainya tetap 1 atau -1. sehingga kecepatan translate objek tetep konstan
        
        playerAnim.SetFloat("speed", movementDirection.magnitude);
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);//translate objek player, agar dapat bergerak
       
    }
    void RotateMovement(){// berguna merotate objek player sesuai nilai movementDirection/ arah gerak player
        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

    }

    void SitDown(){
        playerAnim.SetBool("isSit", true);//trigger animasi duduk
        isSitDown = playerAnim.GetBool("isSit");
    }
    void StandUp(){
        playerAnim.SetBool("isSit", false);//trigger animasi berdiri
        isSitDown = playerAnim.GetBool("isSit");
    }

    void Jump(){
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
    }
}
