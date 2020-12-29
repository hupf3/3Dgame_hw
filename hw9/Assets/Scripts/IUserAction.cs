using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动作接口 √
public interface IUserAction {
    // 控制转动和行进
    void moveForWard ();
    void moveBackWard ();
    void turn (float turnX);
    // 控制射击
    void shoot ();
    // 控制游戏结束
    bool GameOver ();
}