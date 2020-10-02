using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动作管理基类
public class ActionManager: MonoBehaviour, Callback {
    private Dictionary<int, BaseAction> actions = new Dictionary<int, BaseAction>();
    private List<BaseAction> waitingAdd = new List<BaseAction>();
    private List<int> waitingDelete = new List<int>();

    protected void Update() {
        foreach(BaseAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        foreach(KeyValuePair<int, BaseAction> kv in actions) {
            BaseAction ac = kv.Value;
            if (ac.destroy) {
                waitingDelete.Add(ac.GetInstanceID());
            } else if (ac.enable) {
                ac.Update();
            }
        }

        foreach(int key in waitingDelete) {
            BaseAction ac = actions[key]; actions.Remove(key); DestroyObject(ac);
        }
        waitingDelete.Clear();
    }

    public void RunAction(GameObject gameObject, BaseAction action, Callback callback) {
        action.gameObject = gameObject;
        action.transform = gameObject.transform;
        action.callback = callback;
        waitingAdd.Add(action);
        action.Start();
    }

    public void ActionEvent(BaseAction source) {}

}