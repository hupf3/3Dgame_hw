using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring {
    private GameObject ring1, ring2, ring3, ring4, ring5; // 设有五环

    public Ring(){
        ring1 = Resources.Load<GameObject>("Prefab/Ring1");
        ring1 = GameObject.Instantiate(ring1);

        ring2 = Resources.Load<GameObject>("Prefab/Ring2");
        ring2 = GameObject.Instantiate(ring2);

        ring3 = Resources.Load<GameObject>("Prefab/Ring3");
        ring3 = GameObject.Instantiate(ring3);

        ring4 = Resources.Load<GameObject>("Prefab/Ring4");
        ring4 = GameObject.Instantiate(ring4);

        ring5 = Resources.Load<GameObject>("Prefab/Ring5");
        ring5 = GameObject.Instantiate(ring5);

        // 使得圆环能在一起
        ring2.transform.parent = ring1.transform;
        ring3.transform.parent = ring1.transform;
        ring4.transform.parent = ring1.transform;
        ring5.transform.parent = ring1.transform;

        ring1.AddComponent<Score>();
        ring2.AddComponent<Score>();
        ring3.AddComponent<Score>();
        ring4.AddComponent<Score>();
        ring5.AddComponent<Score>();

        // 将圆环的名字设置为分数，这样方便记分
        ring1.name = "1";
        ring2.name = "2";
        ring3.name = "3";
        ring4.name = "4";
        ring5.name = "5";
    }
}
