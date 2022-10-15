using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") Destroy(this);//jika collide dengan player maka objek akan dihapus
    }
}
