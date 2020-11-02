using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    public int _score; // 每个圆环上的得分
    public static int score = 0; // 得分

    int max(int a, int b){
        if (a > b) return a;
        return b;
    }

    // 当发生碰撞时分数增加
    void OnCollisionEnter(Collision collision){
        // print(this.gameObject.name);
        _score = max(_score, int.Parse(this.gameObject.name));
        score += _score;
    }
}
