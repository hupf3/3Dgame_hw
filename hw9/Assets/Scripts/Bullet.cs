using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 子弹设置 √
public class Bullet : MonoBehaviour {
    // 设置爆炸范围
    public float range = 3.0f;
    private TankType tankType;

    // 设置坦克的类型
    public void setTankType (TankType type) {
        tankType = type;
    }

    // 设置碰撞事件
    private void OnCollisionEnter (Collision collision) {
        // 打到自己不算
        if (collision.transform.gameObject.tag == "Enemy" && this.tankType == TankType.ENEMY ||
            collision.transform.gameObject.tag == "Player" && this.tankType == TankType.PLAYER)
            return;

        Factory factory = Singleton<Factory>.Instance;
        ParticleSystem explosion = factory.getParticleSystem ();
        explosion.transform.position = gameObject.transform.position;

        // 爆炸范围内的所有物体都受到伤害
        Collider[] colliders = Physics.OverlapSphere (gameObject.transform.position, range);

        foreach (var collider in colliders) {
            // 设置范围伤害
            float dis = Vector3.Distance (collider.transform.position, gameObject.transform.position);
            float damage;

            // 玩家和敌人设置不同的伤害
            if (collider.tag == "Enemy" && this.tankType == TankType.PLAYER) {
                damage = 50.0f / dis;
                collider.GetComponent<Tank> ().setHP (collider.GetComponent<Tank> ().getHP () - damage);
            } else if (collider.tag == "Player" && this.tankType == TankType.ENEMY) {
                damage = 20.0f / dis;
                collider.GetComponent<Tank> ().setHP (collider.GetComponent<Tank> ().getHP () - damage);
            }

            explosion.Play ();
        }
        if (gameObject.activeSelf) factory.recycleBullet (gameObject);
    }
}