using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 水晶控制 √
public class CrystalControl : MonoBehaviour {
    // 当玩家与水晶相撞
    void OnCollisionEnter (Collision c) {
        SSDirector director;
        if (c.gameObject.tag == "Player") {
            Destroy (this.gameObject);
            director = SSDirector.getInstance ();
            int i = director.currentScenceController.GetCrystal ();
            i = i + 1;
            director.currentScenceController.setCrystal (i);
        }
    }
}