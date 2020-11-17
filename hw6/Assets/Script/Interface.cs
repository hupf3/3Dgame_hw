using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动作事件接口定义 √
namespace Interfaces {
    public interface ISceneController {
        void setCrystal (int c);
        int GetCrystal ();
        void LoadResources ();
    }

    public interface UserAction {
        int GetScore ();
        void Restart ();
        bool GetGameState ();
        void MovePlayer (float moveX, float moveZ);
    }

    public enum SSActionEventType : int { Started, Completed }

    public interface SSActionCallback {
        void SSActionCallback (SSAction s);
    }
}