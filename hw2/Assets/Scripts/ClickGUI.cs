using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 鼠标点击的控制
public class ClickGUI : MonoBehaviour {
	UserAction u;
	RoleController roleController;

	public void setController(RoleController rc) {
		roleController = rc;
	}

	void Start() {
		u = Director.getInstance ().currentSceneController as UserAction;
	}

	void OnMouseDown() {
		if (gameObject.name == "boat") u.MoveBoat ();
		else u.MoveRole (roleController);
	}
}
