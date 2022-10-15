using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fish;
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") Destroy(fish);
        //  Destroy(this);//jika collide dengan player maka objek akan dihapus
    }
}
