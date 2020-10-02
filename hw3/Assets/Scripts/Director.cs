using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 负责实例化
public class Director : System.Object {
	private static Director _instance;
	public SceneController currentSceneController { get; set; }

	public static Director getInstance() {
		if (_instance == null)  _instance = new Director ();
		return _instance;
	}
}
