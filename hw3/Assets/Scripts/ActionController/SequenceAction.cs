using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 顺序动作组合类
public class SequenceAction: BaseAction, Callback {
    public List<BaseAction> sequence;
    public int repeat = 1; // -1:重复 1:一次
    public int start = 0;

    public static SequenceAction getAction(int repeat, int start, List<BaseAction> sequence) {
        SequenceAction action = ScriptableObject.CreateInstance<SequenceAction>();
        action.sequence = sequence;
        action.repeat = repeat;
        action.start = start;
        return action;
    }

    public override void Update() {
        if (sequence.Count == 0)return;
        if (start < sequence.Count) {
            sequence[start].Update();
        }
    }

    public void ActionEvent(BaseAction source) {
        source.destroy = false;
        this.start++;
        if (this.start >= sequence.Count) {
            this.start = 0;
            if (repeat > 0) repeat--;
            if (repeat == 0) { this.destroy = true; this.callback.ActionEvent(this); }
        }
    }

    public override void Start() {
        foreach(BaseAction action in sequence) {
            action.gameObject = this.gameObject;
            action.transform = this.transform;
            action.callback = this;
            action.Start();
        }
    }

    void OnDestroy() {
        foreach(BaseAction action in sequence) DestroyObject(action);
    }
}

