using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 游戏事件管理 √
public class GameEventManager {
    public static GameEventManager Instance = new GameEventManager ();

    // 计分
    public delegate void ScoreEvent ();
    
    // 游戏结束
    public delegate void GameoverEvent ();
    
    public static event ScoreEvent Scoreevent;
    public static event GameoverEvent Gameoverevent;

    private GameEventManager () { }

    // 玩家逃脱
    public void PlayerEscape () {
        if (Scoreevent != null) Scoreevent ();
    }

    // 玩家被捕，游戏结束
    public void PlayerArrest () {
        if (Gameoverevent != null) Gameoverevent ();
    }
}