using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 设置坦克相关属性 √
public class Tank : MonoBehaviour {
    private float health = 100.0f;

    // 初始化生命值
    public Tank () { health = 100.0f; }

    // 设置/获取生命值
    public void setHP (float health) { this.health = health; }
    public float getHP () { return health; }

    // 被攻击
    public void Attacked () { health -= 20; }

    // 设置子弹射击
    public void shoot (TankType type) {
        GameObject bullet = Singleton<Factory>.Instance.getBullets (type);

        // 设置子弹射的方向
        bullet.transform.position = new Vector3 (transform.position.x, 1.5f, transform.position.z) + transform.forward * 1.5f;
        bullet.transform.forward = transform.forward;
        bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * 20, ForceMode.Impulse);
    }
}