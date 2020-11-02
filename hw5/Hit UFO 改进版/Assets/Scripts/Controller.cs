using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 控制器
public class Controller : System.Object{
    private static Controller _instance;

    public Model currentModel { get; set; }
    public bool running{ get; set; } // 判断游戏是否正常运行

    public static Controller getInstance(){
        if (_instance == null){
            _instance = new Controller();
        }
        return _instance;
    }

    // 手动设置游戏帧率
    public int getFPS(){ return Application.targetFrameRate; }
    public void setFPS(int f){ Application.targetFrameRate = f; }
}
