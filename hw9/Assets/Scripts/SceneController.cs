using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 场景控制器 √
public class SceneController : MonoBehaviour, IUserAction {
    public GameDirector director;
    public GameObject player;

    private Factory myFactory;
    private GameObject[] enemies;
    private int enemyCount = 5;
    private bool gameOver = false;

    // 初始化
    private void Awake () {
        director = GameDirector.getInstance ();
        director.currentSceneController = this;

        myFactory = Singleton<Factory>.Instance;
        enemies = new GameObject[enemyCount];

        gameOver = false;
    }

    // 生产玩家和敌人 
    void Start () {
        player = myFactory.getPlayer ();
        for (int i = 0; i < enemyCount; ++i) enemies[i] = myFactory.getEnemys ();
        Player.destroyEvent += setGameOver;
    }

    // 设置相机的位置
    void Update () {
        Camera.main.transform.position = new Vector3 (player.transform.position.x, 20, player.transform.position.z);
    }

    // 获取玩家游戏物体
    public GameObject getPlayer () { return player; }

    // 控制玩家移动
    public void moveForWard () { player.GetComponent<Player> ().moveForWard (); }
    public void moveBackWard () { player.GetComponent<Player> ().moveBackWard (); }
    public void turn (float turnX) { player.GetComponent<Player> ().turn (turnX); }

    // 控制玩家射击
    public void shoot () { player.GetComponent<Player> ().shoot (TankType.PLAYER); }

    // 返回游戏状态
    public bool GameOver () { return gameOver; }
    // 游戏结束
    public void setGameOver () { gameOver = true; }
}