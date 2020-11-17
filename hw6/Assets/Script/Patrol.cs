using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 巡逻兵 √
public class Patrol : MonoBehaviour {
    public int block; // 巡逻兵位置
    public bool status = false; // 判断巡逻兵的状态是否为追逐玩家

    private void Start () {
        // 冻结
        if (gameObject.GetComponent<Rigidbody> ()) gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
    }

    // 旋转方式
    void Update () {
        if (this.gameObject.transform.localEulerAngles.x != 0 || gameObject.transform.localEulerAngles.z != 0)
            gameObject.transform.localEulerAngles = new Vector3 (0, gameObject.transform.localEulerAngles.y, 0);
        
        if (gameObject.transform.position.y != 0)
            gameObject.transform.position = new Vector3 (gameObject.transform.position.x, 0, gameObject.transform.position.z);
    }
}