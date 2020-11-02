using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {
    private GUIStyle font = new GUIStyle(); // 设置文字
    private GUIStyle digit = new GUIStyle(); // 设置数字
    private Ring r;
    private Model action;

    void Start(){
        font.fontSize = 20; font.normal.textColor = Color.blue;
        digit.fontSize = 20; digit.normal.textColor = Color.red;
        r = new Ring();
    }

    void OnGUI(){
        GUI.Label(new Rect(10, 10, 200, 200), "Score：", font);
        GUI.Label(new Rect(75, 10, 200, 200), " " + Score.score, digit);

        GUI.Label(new Rect(10, 40, 200, 200), "Time：", font);
        GUI.Label(new Rect(72, 40, 200, 200), "" + Model.time, digit);
    }
}
