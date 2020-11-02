using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 物理运动
public class CCActionManager1 : Adapter{
    public override void fly(GameObject ufo, float speed){
        CCFlyAction1 action = CCFlyAction1.GetSSAction(speed);
        this.RunAction(ufo, action, this);
    }
}
