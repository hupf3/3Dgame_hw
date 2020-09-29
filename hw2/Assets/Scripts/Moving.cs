using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 关于对象运动的实现
public class Moving: MonoBehaviour {
		
    readonly float speed = 20;

    int cur; // 当前运行的位置
    Vector3 dest, mid; // 设置一个中间位置，使得运动不会穿模

    public void setDestination(Vector3 d) {
        dest = d; mid = d;

        if (d.y == transform.position.y) cur = 2;
        else if (d.y < transform.position.y) mid.y = transform.position.y;
        else mid.x = transform.position.x;
        
        cur = 1;
    }

    public void reset() {
        cur = 0;
    }

    void Update() {
        if (cur == 1) {
            transform.position = Vector3.MoveTowards (transform.position, mid, speed * Time.deltaTime);
            if (transform.position == mid) cur = 2;
        } else if (cur == 2) {
            transform.position = Vector3.MoveTowards (transform.position, dest, speed * Time.deltaTime);
            if (transform.position == dest) cur = 0;
        }
    }
}
