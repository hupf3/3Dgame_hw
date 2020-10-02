using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 监听动作
public interface Callback {
    void ActionEvent(BaseAction source);
}
