using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 场景单实例
public class Singleton : MonoBehaviour{
    protected static Factory instance;

    public static Factory Instance{
        get{
            if (instance == null) instance = (Factory)FindObjectOfType(typeof(Factory));
            return instance;
        }
    }
}