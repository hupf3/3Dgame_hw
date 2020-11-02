using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 工厂模式
public class Factory : MonoBehaviour{
    public List<GameObject> Used_UFO = new List<GameObject>();
    public List<GameObject> Unused_UFO = new List<GameObject>();

    public Adapter act_manager;
    public CCActionManager1 am1;
    public CCActionManager2 am2;

    public int mode;
    // 创建UFO
    public void CreateUFO(){
        if(am1 == null) am1 = GetComponent<CCActionManager1>() as CCActionManager1;
        if(am2 == null) am2 = GetComponent<CCActionManager2>() as CCActionManager2;

        if(mode == 0) act_manager = am1;
        else if(mode == 1) act_manager = am2;

        GameObject obj;
        if (Unused_UFO.Count == 0){
            float num = Random.Range(0f, 3f);
            if (num > 2) obj = Instantiate(Resources.Load("Prefabs/UFO1"), Vector3.zero, Quaternion.identity) as GameObject;
            else if (num > 1) obj = Instantiate(Resources.Load("Prefabs/UFO2"), Vector3.zero, Quaternion.identity) as GameObject;
            else obj = Instantiate(Resources.Load("Prefabs/UFO3"), Vector3.zero, Quaternion.identity) as GameObject;
        }else {
            obj = Unused_UFO[0];
            Unused_UFO.RemoveAt(0);
        }

        // 新的UFO的位置
        float pos_x = Random.Range(-8f, 8f);
        float pos_y = Random.Range(-5f, 5f);
        float pos_z = Random.Range(-2f, 2f);
        obj.transform.position = new Vector3(pos_x, pos_y, 0);
        obj.transform.Rotate(new Vector3(pos_x < 0 ? (-pos_x * 60) : (pos_x * 60), pos_y < 0 ? (-pos_y * 60) : (pos_y * 60), pos_z < 0 ? (-pos_z * 20) : (pos_z * 20)));
        Used_UFO.Add(obj);
    }

    // 回收UFO
    public void RecycleUFO(GameObject obj){
        for (int i = 0; i < Used_UFO.Count; i++){
            if (Used_UFO.ToArray()[i] == obj) Used_UFO.RemoveAt(i);
        }

        // 移除界面 
        obj.transform.position = new Vector3(100,100,100);
        Unused_UFO.Add(obj);
    }
}