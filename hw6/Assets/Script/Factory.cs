using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 巡逻兵制造工厂 √
public class Factory {
    public static Factory fa = new Factory ();
    // 使用过的巡逻兵的位置和对象
    private Dictionary<int, GameObject> used = new Dictionary<int, GameObject> ();

    private Factory () { }

    int[] pos_x = {-5, 0, 7}; int[] pos_z = {7, 3, -6};
    public Dictionary<int, GameObject> GetPatrol () {
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                GameObject patrol = GameObject.Instantiate<GameObject> (Resources.Load<GameObject> ("Prefabs/Patrol"));
                // 设置属性
                patrol.AddComponent<Patrol> ();
                patrol.transform.position = new Vector3 (pos_x[j], 0, pos_z[i]);
                patrol.GetComponent<Patrol> ().block = i * 3 + j;
                patrol.SetActive (true);
                used.Add (i * 3 + j, patrol);
            }
        }
        return used;
    }

    // 恢复位置
    public void InitPatrol () {
        for (int i = 0; i < 3; i++) 
            for (int j = 0; j < 3; j++) 
                used[i * 3 + j].transform.position = new Vector3 (pos_x[j], 0, pos_z[i]);
    }
}