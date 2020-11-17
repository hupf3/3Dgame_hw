using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class FirstSceneController : MonoBehaviour, ISceneController, UserAction {
    Dictionary<int, GameObject> Patrols = null;
    CCActionManager actM = null;
    GameObject player = null;
    Factory fa;

    int score = 0; // 分数
    int initArea = 4; // 玩家初始地点
    bool gameState = false; // 游戏状态
    int crystal = 0; // 水晶

    void Awake () {
        SSDirector director = SSDirector.getInstance ();
        director.currentScenceController = this;
        fa = Factory.fa;
        if (actM == null) actM = gameObject.AddComponent<CCActionManager> ();
        
        if (player == null && Patrols == null) {
            Instantiate (Resources.Load<GameObject> ("Prefabs/Ground"), new Vector3 (0, 0, 0), Quaternion.identity);
            player = Instantiate (Resources.Load ("Prefabs/Player"), new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
            Patrols = fa.GetPatrol ();
        }
        if (player.GetComponent<Rigidbody> ()) player.GetComponent<Rigidbody> ().freezeRotation = true;
    }

    void Update () {
        if (player.transform.localEulerAngles.x != 0 || player.transform.localEulerAngles.z != 0) {
            player.transform.localEulerAngles = new Vector3 (0, player.transform.localEulerAngles.y, 0);
        }
        if (player.transform.position.y <= 0) {
            player.transform.position = new Vector3 (player.transform.position.x, 0, player.transform.position.z);
        }
    }

    public void setCrystal (int i) { crystal = i; }

    public int GetCrystal () { return crystal; }

    public bool GetGameState () { return gameState; }

    public void LoadResources () {}

    public int GetScore () { return score; }

    public void Restart () {
        player.GetComponent<Animator> ().Play ("idle");
        foreach (GameObject x in Patrols.Values) 
            x.GetComponent<Animator> ().Play ("Idle");
        fa.InitPatrol ();
        gameState = true;
        score = 0;
        player.transform.position = new Vector3 (0, 0, 0);
        Patrols[initArea].GetComponent<Patrol> ().status = true;
        actM.Follow (Patrols[initArea], player);
        foreach (GameObject x in Patrols.Values) {
            if (!x.GetComponent<Patrol> ().status)  actM.GoRoute (x);
        }
    }

    // 设置玩家位置
    public void SetPos (int x) {
        if (initArea != x && gameState) {
            Patrols[initArea].GetComponent<Animator> ().SetBool ("run", false);
            Patrols[initArea].GetComponent<Patrol> ().status = false;
            initArea = x;
        }
    }

    // 获取分数
    void AddScore () {
        if (gameState) {
            ++ score;
            Patrols[initArea].GetComponent<Patrol> ().status = true;
            actM.Follow (Patrols[initArea], player);
            Patrols[initArea].GetComponent<Animator> ().SetBool ("run", true);
        }
    }

    void Gameover () {
        actM.InitClear ();
        Patrols[initArea].GetComponent<Patrol> ().status = false;
        Patrols[initArea].GetComponent<Animator> ().SetTrigger ("attack");
        player.GetComponent<Animator> ().SetTrigger ("death");
        gameState = false;
    }

    public void MovePlayer (float moveX, float moveZ) {
        if (gameState && player != null) {
            if (moveZ != 0) player.GetComponent<Animator> ().SetBool ("run", true);
            else player.GetComponent<Animator> ().SetBool ("run", false);
            
            player.transform.Translate (0, 0, moveZ * 4f * Time.deltaTime);
            player.transform.Rotate (0, moveX * 50f * Time.deltaTime, 0);
        }
    }

    void OnEnable () {
        GameEventManager.Scoreevent += AddScore;
        GameEventManager.Gameoverevent += Gameover;
    }

    void OnDisable () {
        GameEventManager.Scoreevent -= AddScore;
        GameEventManager.Gameoverevent -= Gameover;
    }
}