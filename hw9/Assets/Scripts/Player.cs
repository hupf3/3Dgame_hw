using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家设置 √
public class Player : Tank {
    // 玩家坦克被摧毁
    public delegate void DestroyPlayer ();
    public static event DestroyPlayer destroyEvent;

    // 设置初始生命值
    void Start () { setHP (100); }

    void Update () {
        if (getHP () <= 0) {
            this.gameObject.SetActive (false);
            destroyEvent ();
        }
    }

    // 前后方向移动
    public void moveForWard () {
        gameObject.GetComponent<Rigidbody> ().velocity = gameObject.transform.forward * 20;
    }
    public void moveBackWard () {
        gameObject.GetComponent<Rigidbody> ().velocity = gameObject.transform.forward * (-20);
    }

    // 实现左右转向
    public void turn (float turnX) {
        float x = gameObject.transform.localEulerAngles.x;
        float y = gameObject.transform.localEulerAngles.y + turnX * 2;
        gameObject.transform.localEulerAngles = new Vector3 (x, y, 0);
    }
}