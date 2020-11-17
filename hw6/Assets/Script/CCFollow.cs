using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 跟随动作 √
public class CCFollow : SSAction {
    public GameObject v; // 目标
    public float speed; // 移动速度

    private CCFollow () {}
    public override void Start () {}

    public static CCFollow getAction (GameObject v, float speed) {
        CCFollow action = ScriptableObject.CreateInstance<CCFollow> ();
        action.v = v; action.speed = speed;
        return action;
    }

    public override void Update () {
        this.transform.position = Vector3.MoveTowards (transform.position, v.transform.position, speed * Time.deltaTime);
        Quaternion rotation = Quaternion.LookRotation (v.transform.position - gameObject.transform.position, Vector3.up);
        gameObject.transform.rotation = rotation;

        // 追到了玩家
        if (gameObject.GetComponent<Patrol> ().status == false || transform.position == v.transform.position) {
            destroy = true;
            CallBack.SSActionCallback (this);
        }
    }
}