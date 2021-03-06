﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UserGUI : MonoBehaviour {
	private UserAction u;
	public int isWin = 0;// 1:Gameover 2:Win
	public int time; // 游戏运行时间
	GUIStyle ssize, buttons, tsize;

	void Start() {
		u = Director.getInstance ().currentSceneController as UserAction;

		// 设置字体大小
		ssize = new GUIStyle(); tsize = new GUIStyle();
		ssize.fontSize = 45; tsize.fontSize = 20;
		ssize.alignment = TextAnchor.MiddleCenter;

		// 设置按钮大小
		buttons = new GUIStyle("button");
		buttons.fontSize = 30;

		// 设置游戏的时长
		time = 60;
	}
	// 判断是否胜利或失败，然后重置
	void OnGUI() {
		GUI.Label(new Rect(0, 0, 100, 50), "Time:  " + time, tsize);
		if (isWin == 1) {
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 80, 100, 50), "Gameover!", ssize);
			if (GUI.Button(new Rect(Screen.width / 2-65, Screen.height / 2, 140, 70), "Restart", buttons)) {
				isWin = 0; u.restart ();
			}
		} else if(isWin == 2) {
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 80, 100, 50), " Win!", ssize);
			if (GUI.Button(new Rect(Screen.width / 2 - 65, Screen.height / 2, 140, 70), "Restart", buttons)) {
				isWin = 0; u.restart ();
			}
		}
	}
}
