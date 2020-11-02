using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    private GameObject obj;

    public static int time;

    void UpdateTime(){ time ++; }

    // 时间的每秒递增
    void Awake() {
        InvokeRepeating("UpdateTime", 1f, 1f);
    }

    void Start(){
        // 初始化飞镖
        obj = Resources.Load<GameObject>("Prefab/Dart");
        time = 0;
    }

    void Update(){
        // 实现飞镖的发射
        if (Input.GetMouseButtonDown(0)){
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit h; Vector3 v;
            if (Physics.Raycast(r, out h)){
                v = h.point;
                v.z = Camera.main.transform.position.z + 2;
                obj.transform.position = v;

                GameObject dart = GameObject.Instantiate(obj);
                dart.AddComponent<ModelController>();
                dart.AddComponent<Rigidbody>();
            }
        }
    }
}
