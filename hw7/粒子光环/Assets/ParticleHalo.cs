using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHalo : MonoBehaviour {
    ParticleSystem particleSystem; // 粒子系统
    ParticleSystem.Particle[] particlesArray; // 粒子数组
    public int count = 5000; // 粒子数量
    public float size = 0.1f; // 粒子大小
    public float minRadius = 7.0f; // 最小半径
    public float maxRadius = 13.0f; // 最大半径
    public float speed = 2f; // 初始速度
    public float pingPong = 0.02f; // 游离范围
    public Gradient gradient; // 颜色
    CirclePosition[] circles; // 粒子极坐标位置
    public float time = 0; // 时间

    // 极坐标类
    class CirclePosition {
        public float radius = 0f, angle = 0f, time = 0f;
        public CirclePosition (float radius, float angle, float time) {
            this.radius = radius; //半径    
            this.angle = angle; //角度
            this.time = time; //运行时间
        }
    }

    // 初始化粒子的位置
    void SetPos(){
        // 使得粒子集中在平均半径附近
        float midRadius = (maxRadius + minRadius) / 2;
        float minRate = Random.Range (1.0f, midRadius / minRadius);
        float maxRate = Random.Range (midRadius / maxRadius, 1.0f);
        for (int i = 0; i < count; i++) {
            // 设置半径
            float radius = Random.Range (minRadius * minRate, maxRadius * maxRate);

            // 设置角度
            float angle = (float) i / count * 360f;
            float theta = angle / 180 * Mathf.PI;

            // 设置粒子位置
            circles[i] = new CirclePosition (radius, angle, (float) i / count * 360f);
            particlesArray[i].position = new Vector3 (radius * Mathf.Cos (theta), radius * Mathf.Sin (theta), 0);
        }
    }

    void Start () {
        // 初始化粒子数组
        particlesArray = new ParticleSystem.Particle[count];
        circles = new CirclePosition[count];

        // 初始化粒子系统
        particleSystem = gameObject.GetComponent<ParticleSystem> ();
        particleSystem.maxParticles = count;
        particleSystem.startSize = size;
        particleSystem.Emit (count);
        particleSystem.GetParticles (particlesArray);
        
        SetPos();
        particleSystem.SetParticles (particlesArray, particlesArray.Length);
    }

    void Update () {
        for (int i = 0; i < count; ++i) {
            // 保证角度在360以内
            circles[i].angle = (circles[i].angle - Random.Range (0.4f, 0.6f) + 360f) % 360f;
            float theta = circles[i].angle / 180 * Mathf.PI;

            // 粒子半径变化
            circles[i].time += Time.deltaTime;
            circles[i].radius += Mathf.PingPong (circles[i].time / minRadius / maxRadius, pingPong) - pingPong / 2.0f;

            // 确保粒子在规定范围运动
            if (circles[i].radius < minRadius) circles[i].radius += Time.deltaTime;
            else if (circles[i].radius > maxRadius) circles[i].radius -= Time.deltaTime;

            // 粒子数组位置设置
            particlesArray[i].position = new Vector3 (circles[i].radius * Mathf.Cos (theta), circles[i].radius * Mathf.Sin (theta), 0);
        }
        particleSystem.SetParticles (particlesArray, particlesArray.Length);
    }
}