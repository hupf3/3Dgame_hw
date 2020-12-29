using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 设置界面 √
public class IUserGUI : MonoBehaviour {
    IUserAction action;

    void Start () {
        action = GameDirector.getInstance ().currentSceneController as IUserAction;
    }

    void Update () {
        if (!action.GameOver ()) {
            // 监听键盘
            if (Input.GetKey (KeyCode.W)) action.moveForWard ();
            if (Input.GetKey (KeyCode.S)) action.moveBackWard ();
            if (Input.GetKeyDown (KeyCode.Space)) action.shoot ();
            float turnX = Input.GetAxis ("Horizontal");

            action.turn (turnX);
        }
    }

    void OnGUI () {
        // 游戏结束
        if (action.GameOver ()) {
            GUIStyle font = new GUIStyle ();
            font.fontSize = 50;
            font.normal.textColor = Color.red;
            GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50), "Game Over!", font);
        }
    }
}