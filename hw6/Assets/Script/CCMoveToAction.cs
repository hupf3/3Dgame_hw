using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 简单动作实现，将一个物体移动到指定位置，并通知任务完成 √
public class CCMoveToAction : SSAction {
    public Vector3 target; // 位置
    public float speed;
    public int block; // 对应于地图中的位置

    private CCMoveToAction () { }

    // 获取动作
    public static CCMoveToAction getAction (int b, float v, Vector3 p) {
        CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction> ();
        action.target = p;
        action.speed = v;
        action.block = b;
        return action;
    }

    public override void Update () {
        if (this.transform.position == target) {
            destroy = true;
            CallBack.SSActionCallback (this);
        }
        this.transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
    }

    public override void Start () {
        // 转变方向
        Quaternion rotation = Quaternion.LookRotation (target - transform.position, Vector3.up);
        transform.rotation = rotation;
    }
}