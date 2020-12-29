using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 敌人坦克设置 √
public class Enemy : Tank {
    // 敌人坦克被摧毁，进行回收
    public delegate void RecycleEnemy (GameObject enemy);
    public static event RecycleEnemy recycleEnemy;

    // 玩家位置
    private Vector3 playerPos;

    // 游戏是否结束
    private bool gameover;

    private void Start () {
        playerPos = GameDirector.getInstance ().currentSceneController.getPlayer ().transform.position;
        // 启动协程
        StartCoroutine (shoot ());
    }

    void Update () {
        playerPos = GameDirector.getInstance ().currentSceneController.getPlayer ().transform.position;
        gameover = GameDirector.getInstance ().currentSceneController.GameOver ();
        if (!gameover) {
            if (getHP () <= 0 && recycleEnemy != null) recycleEnemy (this.gameObject);
            else {
                // 向玩家移动
                NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent> ();
                agent.SetDestination (playerPos);
            }
        } else {
            // 游戏结束后停止运动
            NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent> ();
            agent.velocity = Vector3.zero;
            agent.ResetPath ();
        }
    }

    // 控制射击
    IEnumerator shoot () {
        while (!gameover) {
            for (float i = 1; i > 0; i -= Time.deltaTime) yield return 0;

            // 射程
            if (Vector3.Distance (playerPos, gameObject.transform.position) < 10) shoot (TankType.ENEMY);
        }
    }
}