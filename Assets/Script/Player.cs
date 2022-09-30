using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public float jumpForce = 100f;
    public float rotationSpeed;
    public BoxCollider groundBox;
    Animator playerAnim;
    Vector3 movementDirection;

    bool isSitDown = false;

    void Start()
    {
        playerAnim = this.GetComponent<Animator>();
        isSitDown = playerAnim.GetBool("isSit");
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

        movementDirection = new Vector3(horizontalMove, 0, verticalMove);
        // Debug.Log("before "+movementDirection);
        movementDirection.Normalize();
        // Debug.Log("after "+movementDirection);
        // Debug.Log("magnitude "+movementDirection.magnitude);
        
        playerAnim.SetFloat("speed", movementDirection.magnitude);
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
    }
    void RotateMovement(){
        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    void SitDown(){
        playerAnim.SetBool("isSit", true);
        isSitDown = playerAnim.GetBool("isSit");
    }
    void StandUp(){
        playerAnim.SetBool("isSit", false);
        isSitDown = playerAnim.GetBool("isSit");
    }
    void Jump(){
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
    }
}
