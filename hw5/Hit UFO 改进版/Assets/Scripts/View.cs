using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 界面设置
public class View : MonoBehaviour{
    private Model action;
    private GUIStyle font1 = new GUIStyle(); // 设置文字
    private GUIStyle font2 = new GUIStyle(); // 设置文字
    private GUIStyle font3 = new GUIStyle(); // 设置文字
    private GUIStyle digit = new GUIStyle(); // 设置数字

    void Start(){
        action = Controller.getInstance().currentModel as Model;

        font1.fontSize = 20; font1.normal.textColor = Color.blue;
        digit.fontSize = 20; digit.normal.textColor = Color.red;
        font2.fontSize = 60;
        font3.fontSize = 60; font3.normal.textColor = Color.red;
    }

    public void OnGUI(){
        // 游戏只进行5轮(round)
        if (action.round >= 6){
            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 150, 200, 200), "Game Over！", font2);
            GUI.Label(new Rect(Screen.width / 2 - 180, Screen.height / 2 - 50, 200, 200), "You Get Score: " + action.score, font3);
            action.GameOver();
        }else {
            GUI.Label(new Rect(10, 10, 200, 200),"Round: ", font1);
            GUI.Label(new Rect(75, 10, 200, 200),"" + action.round, digit);

            GUI.Label(new Rect(10, 40, 200, 200),"Score: ", font1); 
            GUI.Label(new Rect(72, 40, 200, 200),"" + action.score, digit);

            GUI.Label(new Rect(10, 70, 200, 200),"Trial: ", font1);
            GUI.Label(new Rect(55, 70, 200, 200),"" + action.trial, digit);

            GUI.Label(new Rect(Screen.width - 80, 10, 200, 200),"Time: ", font1);
            GUI.Label(new Rect(Screen.width - 30, 10, 200, 200),"" + action.time, digit);

            // 下一个回合
            if (GUI.Button(new Rect(10, Screen.height - 230, 100, 50), "Next Round")) action.NextRound();

            // 暂停
            if (GUI.Button(new Rect(10, Screen.height - 150, 100, 50), "Pause")) action.Pause();
            
            // 重新开始
            if (GUI.Button(new Rect(10, Screen.height - 80, 100, 50), "Restart")) action.Restart();
            
            // 更换模式
            if (GUI.Button(new Rect(10, Screen.height - 290, 100, 50), "Change Mode")) action.Changemode();
        } 
    }

}
