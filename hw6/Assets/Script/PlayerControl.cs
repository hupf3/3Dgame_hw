using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家控制 √
public class PlayerControl : MonoBehaviour {
    // 玩家与侦察兵相撞，游戏结束
    void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "Player") GameEventManager.Instance.PlayerArrest ();
        
    }
}