using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour {
    private float speed;
    private bool fly;

    void Start(){
        fly = true;
        speed = 30.0f; // 速度快一点不容易脱靶
    }

    void Update(){
        if (this.gameObject.transform.position.y < -5) Destroy(this.gameObject);
        
        if (fly){
            Vector3 v = this.gameObject.transform.position;
            v.z -= -speed * Time.deltaTime;
            this.gameObject.transform.position = v;
        }
    }

    // 当发生碰撞时
    void OnCollisionEnter(Collision collision){
        fly = false;
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());
    }
}
