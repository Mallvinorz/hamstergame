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

        movementDirection = new Vector3(horizontalMove, 0, verticalMove);
        // Debug.Log("before "+movementDirection);
        movementDirection.Normalize();
        // Debug.Log("after "+movementDirection);
        // Debug.Log("magnitude "+movementDirection.magnitude);
        
        playerAnim.SetFloat("speed", movementDirection.magnitude);
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        // transform.localEulerAngles = new Vector3(transform.eulerAngles.x, cameraTransform.eulerAngles.y, transform.eulerAngles.z);
        Debug.Log(cameraTransform.forward);
        Debug.Log(movementDirection);
    }
    void RotateMovement(){


        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            // float targetRotation = Mathf.Atan2 (movementDirection.x, movementDirection.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
			// transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, rotationSpeed);

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
