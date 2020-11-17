using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

// 视图
public class View : MonoBehaviour {
    UserAction userAction;
    ISceneController iSceneController;
    Factory fa;
    bool state = false;
    bool win = false; // 判断是否获胜
    float startTime; // 开始时间
    
    private GUIStyle font = new GUIStyle(); // 设置文字
    private GUIStyle digit = new GUIStyle(); // 设置数字
    
    

    void Start () {
        font.fontSize = 20; font.normal.textColor = Color.blue;
        digit.fontSize = 20; digit.normal.textColor = Color.red;

        userAction = SSDirector.getInstance ().currentScenceController as UserAction;
        iSceneController = SSDirector.getInstance ().currentScenceController as ISceneController;
        startTime = Time.time;
    }

    // 控制玩家移动
    private void Update () {
        float moveX = Input.GetAxis ("Horizontal");
        float moveZ = Input.GetAxis ("Vertical");
        userAction.MovePlayer (moveX, moveZ);
    }

    private void OnGUI () {
        if (!state) startTime = Time.time;
        GUI.Label(new Rect(10, 10, 200, 200), "时间: ", font);
        GUI.Label(new Rect(72, 10, 200, 200), "" + ((int) (Time.time - startTime)).ToString (), digit);

        GUI.Label(new Rect(10, 40, 200, 200), "分数: ", font);
        GUI.Label(new Rect(75, 40, 200, 200), "" + userAction.GetScore().ToString (), digit); 

        GUI.Label(new Rect(10, 70, 200, 200), "已采集到的宝石: ", font);
        GUI.Label(new Rect(75, 70, 200, 200), "                " + iSceneController.GetCrystal().ToString (), digit);

        if (state){
            if (!userAction.GetGameState ()) state = false;
            // 取到5个宝石即为成功
            if (iSceneController.GetCrystal () >= 5){
                win = true;
                state = false;
            }
        } else{
            if (win){
                GUIStyle fontStyle = new GUIStyle ();
                fontStyle.alignment = TextAnchor.MiddleCenter;
                fontStyle.fontSize = 25;
                fontStyle.normal.textColor = Color.white;
                GUI.Label (new Rect (Screen.width / 2 - 25, Screen.height / 2 - 80, 100, 50), "获胜!", fontStyle);
                fa = Factory.fa;
                fa.InitPatrol ();

                if (GUI.Button (new Rect (Screen.width / 2 - 30, Screen.height / 2 - 30, 100, 50), "退出")){
                    UnityEditor.EditorApplication.isPlaying = false;
                }
            } else if (GUI.Button (new Rect (Screen.width / 2 - 30, Screen.height / 2 - 30, 100, 50), "重新开始")) {
                state = true;
                iSceneController.LoadResources ();
                startTime = Time.time;
                userAction.Restart ();
            }
        }
    }
}