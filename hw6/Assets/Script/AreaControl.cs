using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 九宫格区域控制 √
public class AreaControl : MonoBehaviour {
    public int block = 0;
    FirstSceneController sc;

    private void Start () {
        sc = SSDirector.getInstance ().currentScenceController as FirstSceneController;
    }

    // 玩家进入需要进行标记
    void OnTriggerEnter (Collider c) {
        if (c.gameObject.tag == "Player") {
            sc.SetPos (block);
            GameEventManager.Instance.PlayerEscape ();
        }
    }
}