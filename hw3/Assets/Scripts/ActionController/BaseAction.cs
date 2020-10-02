using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动作基类
public class BaseAction : ScriptableObject{

    public bool enable = true;
    public bool destroy = false;

    public GameObject gameObject { get; set; }
    public Transform transform { get; set; }
    public Callback callback { get; set; }

    public virtual void Start(){
        throw new System.NotImplementedException();
    }

    public virtual void Update(){
        throw new System.NotImplementedException();
    }
}

    
