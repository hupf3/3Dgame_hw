using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 场景单实例模式 √
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    protected static T instance;
    public static T Instance {
        get {
            if (instance == null) instance = (T) FindObjectOfType (typeof (T));

            return instance;
        }
    }
}