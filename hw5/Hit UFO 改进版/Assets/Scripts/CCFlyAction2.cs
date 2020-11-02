using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction2 : SSAction{

    public float speed;

    public static CCFlyAction2 GetSSAction(float speed){
        CCFlyAction2 action = ScriptableObject.CreateInstance<CCFlyAction2>();
        action.speed = speed;
        return action;
    }

    // Update is called once per frame
    public override void Update(){
        Vector3 v = new Vector3(this.gameobject.transform.localRotation.x, this.gameobject.transform.localRotation.y, this.gameobject.transform.localRotation.z);
        this.gameobject.GetComponent<Rigidbody>().AddForce(v * 10f * speed);
        
        if(this.gameobject.transform.position.x > 10 || this.gameobject.transform.position.x < -10){
            this.destory=true;
            this.callback.SSActionEvent (this);
        }
        if(this.gameobject.transform.position.y > 10 || this.gameobject.transform.position.y < -10){
            this.destory=true;
            this.callback.SSActionEvent (this);
        }
        if(this.gameobject.transform.position.z < -10){
            this.destory=true;
            this.callback.SSActionEvent (this);
        }
    }
}
