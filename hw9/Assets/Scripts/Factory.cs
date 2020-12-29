using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TankType { PLAYER, ENEMY }

// 工厂模式
public class Factory : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;
    public GameObject bullet;
    public ParticleSystem explosion;

    private List<GameObject> usedTanks;
    private List<GameObject> freeTanks;
    private List<GameObject> usedBullets;
    private List<GameObject> freeBullets;

    private GameObject player_t;
    private List<ParticleSystem> particles;

    // 初始化
    private void Awake () {
        usedTanks = new List<GameObject> ();
        freeTanks = new List<GameObject> ();
        usedBullets = new List<GameObject> ();
        freeBullets = new List<GameObject> ();
        particles = new List<ParticleSystem> ();

        player_t = GameObject.Instantiate<GameObject> (player) as GameObject;
        player_t.SetActive (true);
        player_t.transform.position = Vector3.zero;
    }

    void Start () { Enemy.recycleEnemy += recycleEnemy; }

    // 获取玩家
    public GameObject getPlayer () {return player_t;}

    // 获取敌人
    public GameObject getEnemys () {
        GameObject newT = null;
        if (freeTanks.Count <= 0) {
            newT = GameObject.Instantiate<GameObject> (enemy) as GameObject;
            usedTanks.Add (newT);
            newT.transform.position = new Vector3 (Random.Range (-100, 100), 0, Random.Range (-100, 100));
        } else {
            newT = freeTanks[0];
            freeTanks.RemoveAt (0);
            usedTanks.Add (newT);
        }

        newT.SetActive (true);
        return newT;
    }

    // 获取子弹
    public GameObject getBullets (TankType type) {
        GameObject newBullet;
        if (freeBullets.Count <= 0) {
            newBullet = GameObject.Instantiate<GameObject> (bullet) as GameObject;
            usedBullets.Add (newBullet);
            newBullet.transform.position = new Vector3 (Random.Range (-100, 100), 0, Random.Range (-100, 100));
        } else {
            newBullet = freeBullets[0];
            freeBullets.RemoveAt (0);
            usedBullets.Add (newBullet);
        }

        newBullet.GetComponent<Bullet> ().setTankType (type);
        newBullet.SetActive (true);
        return newBullet;
    }

    // 获取粒子系统
    public ParticleSystem getParticleSystem () {
        foreach (var particle in particles){
            if (!particle.isPlaying) return particle;
        }

        ParticleSystem newT = GameObject.Instantiate<ParticleSystem> (explosion);
        particles.Add (newT);
        return newT;
    }

    // 回收坦克
    public void recycleEnemy (GameObject enemyTank) {
        usedTanks.Remove (enemyTank);
        freeTanks.Add (enemyTank);
        enemyTank.GetComponent<Rigidbody> ().velocity = Vector3.zero;
        enemyTank.SetActive (false);
    }

    // 回收子弹
    public void recycleBullet (GameObject Bullet) {
        usedBullets.Remove (Bullet);
        freeBullets.Add (Bullet);
        Bullet.GetComponent<Rigidbody> ().velocity = Vector3.zero;
        Bullet.SetActive (false);
    }
}