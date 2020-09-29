using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用户或玩家可以进行的操作
public interface UserAction {
    void MoveBoat();
    void MoveRole(RoleController r);
    void restart();
}
