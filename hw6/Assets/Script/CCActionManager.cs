using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

// 动作组合 √
public class CCActionManager : SSActionManager, SSActionCallback {
    // 动作序列
    Dictionary<int, CCMoveToAction> actionList = new Dictionary<int, CCMoveToAction> ();

    // 巡逻兵跟随玩家
    public void Follow (GameObject p, GameObject player) {
        if (actionList.ContainsKey (p.GetComponent<Patrol> ().block)) actionList[p.GetComponent<Patrol> ().block].destroy = true;
        CCFollow action = CCFollow.getAction (player, 0.8f);
        RunAction (p.gameObject, action, this);
    }

    // 行走路线
    public void GoRoute (GameObject p) {
        CCMoveToAction action = CCMoveToAction.getAction (p.GetComponent<Patrol> ().block, 0.6f, GetPos (p));
        actionList.Add (p.GetComponent<Patrol> ().block, action);
        RunAction (p.gameObject, action, this);
    }

    // 行走中获取新的行走地点
    private Vector3 GetPos (GameObject p) {
        Vector3 pos = p.transform.position;
        int block = p.GetComponent<Patrol> ().block;

        // 获取新的移动方向
        float x1 = -5.0f + (block % 3) * 8.7f; float x2 = -14.1f + (block % 3) * 10.3f;
        float z1 = 12.3f - (block / 3) * 8.95f; float z2 = 4.9f - (block / 3) * 9.54f;
        
        Vector3 vec = new Vector3 (Random.Range (-2f, 2f), 0, Random.Range (-2f, 2f)); Vector3 nextPos = pos + vec;

        while (!(nextPos.x < x1 && nextPos.x > x2 && nextPos.z < z1 && nextPos.z > z2)) {
            vec = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
            nextPos = pos + vec;
        }
        
        return nextPos;
    }

    // 初始化清空
    public void InitClear () {
        foreach (CCMoveToAction a in actionList.Values) a.destroy = true;
        actionList.Clear ();
    }

    // 回调函数
    public void SSActionCallback (SSAction source) {
        if (actionList.ContainsKey (source.gameObject.GetComponent<Patrol> ().block)) actionList.Remove (source.gameObject.GetComponent<Patrol> ().block);
        GoRoute (source.gameObject);
    }
}