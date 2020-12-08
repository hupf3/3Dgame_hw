using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodGUI : MonoBehaviour {
    private float preBlood = 0f;
    private float curBlood = 0f;
    GameObject btn1, btn2;
    public Slider bloodBar;

    private void Start() {
        btn1 = GameObject.Find("btn1"); Button a = btn1.GetComponent<Button>();
        btn2 = GameObject.Find("btn2"); Button b = btn2.GetComponent<Button>();
        // 添加代理事件
        a.onClick.AddListener(delegate () {
            this.OnClick(btn1);
        });
        b.onClick.AddListener(delegate () {
            this.OnClick(btn2);
        });
    }

    private void OnClick(GameObject sender) {
        if (sender.name == "btn1") curBlood = curBlood - 10f < 0f ? 0f : curBlood - 10f;
        if (sender.name == "btn2") curBlood = curBlood + 10f > 100f ? 100f : curBlood + 10f;
    }

    void Update() {
        // 使血条更加平滑
        preBlood = Mathf.Lerp(preBlood, curBlood, 0.1f);
        bloodBar.value = preBlood;
        transform.rotation = Quaternion.LookRotation(Vector3.forward);
    }
}