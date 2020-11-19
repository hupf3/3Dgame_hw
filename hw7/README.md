# 粒子系统与流动效果

- [粒子系统与流动效果](#粒子系统与流动效果)
  - [作业与练习](#作业与练习)
  - [作业说明](#作业说明)
  - [实验运行说明](#实验运行说明)
  - [博客地址](#博客地址)
  - [汽车尾气模拟](#汽车尾气模拟)
    - [实验截图和视频](#实验截图和视频)
    - [实验流程](#实验流程)
    - [代码实现](#代码实现)
  - [粒子光环](#粒子光环)
    - [实验截图和视频](#实验截图和视频-1)
    - [实验流程](#实验流程-1)
    - [代码实现](#代码实现-1)
  - [实验总结](#实验总结)

## 作业与练习

本次作业基本要求是**三选一**

1、简单粒子制作

- 按参考资源要求，制作一个粒子系统，[参考资源](http://www.cnblogs.com/CaomaoUnity3d/p/5983730.html)
- 使用 3.3 节介绍，用代码控制使之在不同场景下效果不一样

2、完善官方的“汽车尾气”模拟

- 使用官方资源资源 Vehicle 的 car， 使用 Smoke 粒子系统模拟启动发动、运行、故障等场景效果

3、参考 http://i-remember.fr/en 这类网站，使用粒子流编程控制制作一些效果， 如“粒子光环”

- 可参考以前作业

## 作业说明

本次作业要求是三选一，为了能够丰富作业内容，我选择了两个内容进行了实现：汽车尾气 + 粒子光环

## 实验运行说明

将 `Assets` 文件夹下载到本地，然后直接通过unity打开该文件即可成功运行，或者新建个项目，用该 `Assets` 文件夹覆盖原有的，打开后即可正常运行

## 博客地址

[传送门](https://blog.csdn.net/qq_43267773/article/details/109829086)

## 汽车尾气模拟

### 实验截图和视频

本次实验三种状态下的粒子效果如下所示：

- 发动

  <img src="https://img-blog.csdnimg.cn/2020111923075737.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- 运行

  <img src="https://img-blog.csdnimg.cn/20201119230816813.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- 故障

  <img src="https://img-blog.csdnimg.cn/20201119230839158.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

实验运行视频地址：[传送门](https://www.bilibili.com/video/BV1ey4y1z7VB)

### 实验流程

首先做一个地面 `Ground`，方便汽车在上面放置观察

本次实验用到的汽车模型，是官方资源 `Stantard Assets` 中的汽车模型，结构如下：

<img src="https://img-blog.csdnimg.cn/20201119230516903.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

最终的显示效果如下：

<img src="https://img-blog.csdnimg.cn/20201119230533542.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

本次需要模拟三种粒子效果，所以在汽车模型中的 `Particles` 中添加 `begin`, `run`, `damage` 三种粒子模型：

<img src="https://img-blog.csdnimg.cn/20201119231921321.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

首先介绍一下粒子面板的不同属性的作用是什么然后在后续的粒子系统实现中直接展示设置即可：

- `Duration` ：表示粒子的持续时间

- `Looping` ：表示是否循环发射粒子  

- `Start Lifetime` ：表示粒子的存在时间

- `Start Speed` ： 表示粒子的初始速度。  

- `Start Size` ： 表示粒子的初始大小。  
- `Rate ove Time` ：表示每一次发射器发射的粒子数目。  
- `Shape `：表示发射器的形状。
- `Angle `：表示发射粒子的角度。
- `Radius`： 发射粒子范围的半径。  
- `Color over Lifetime`：发射粒子的颜色渐变
- `Size over Lifetime`：发射粒子的大小渐变
- `Material`：发射粒子的材料

下面分别介绍三个粒子系统的不同设置：

- `begin`：发射粒子的颜色渐变过程可以根据自己的喜好进行修改，该粒子系统的发射材料我选择的是 `ParticleSmokeMobile`

  <img src="https://img-blog.csdnimg.cn/20201119233718147.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  <img src="https://img-blog.csdnimg.cn/20201119233806265.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom: 33%;" />

  <img src="https://img-blog.csdnimg.cn/20201119233924672.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  <img src="https://img-blog.csdnimg.cn/20201119233950230.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- `run`: 发射粒子的颜色渐变过程可以根据自己的喜好进行修改，该粒子系统的发射材料我选择的是 `ParticleSmokeMobile`

  <img src="https://img-blog.csdnimg.cn/20201119233232602.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  <img src="https://img-blog.csdnimg.cn/20201119233304772.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  <img src="https://img-blog.csdnimg.cn/20201119233341839.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  <img src="https://img-blog.csdnimg.cn/20201119233516785.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- `damage`：发射粒子的颜色渐变过程可以根据自己的喜好进行修改，该粒子系统的发射材料我选择的是 `ParticleBurnout`

  <img src="https://img-blog.csdnimg.cn/20201119234022769.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  <img src="https://img-blog.csdnimg.cn/2020111923404584.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  <img src="https://img-blog.csdnimg.cn/20201119234113389.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  <img src="https://img-blog.csdnimg.cn/20201119234133771.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

### 代码实现

本次只需实现一个代码文件 `Status`，然后将其挂载到模型 `Car` 上，该文件的作用是改变汽车模型的粒子系统，该代码文件有一个全局变量 `status`，值为0时，代表启动；值为1时，代表运行；值为2时，代表故障。在游戏运行时，即可手动进行修改

<img src="https://img-blog.csdnimg.cn/20201119234431948.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int status; // 0 : 启动；1 : 运行；2 : 损坏
    private GameObject begin, run, damage;

    void Start(){
        status = -1;
        begin = transform.Find("Particles/begin").gameObject;
        run = transform.Find("Particles/run").gameObject;
        damage = transform.Find("Particles/damage").gameObject;

        begin.SetActive(false);
        run.SetActive(false);
        damage.SetActive(false);
    }

    void Update(){
        if (status == 0){
            begin.SetActive(true);
            run.SetActive(false);
            damage.SetActive(false);
        }else if (status == 1){
            begin.SetActive(false);
            run.SetActive(true);
            damage.SetActive(false);
        }else if (status == 2){
            begin.SetActive(false);
            run.SetActive(false);
            damage.SetActive(true);
        }
    }
}

```

## 粒子光环

### 实验截图和视频

粒子效果的截图如下：

<img src="https://img-blog.csdnimg.cn/20201119231439938.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

实验运行视频地址：[传送门](https://www.bilibili.com/video/BV1yf4y1q7Cu)

### 实验流程

首先为了实现更好的效果需要将背景颜色调为黑色，这样能够更加显示出光环的亮，我们需要找到此路径：`Window->Rendering->Lighting`：

<img src="https://img-blog.csdnimg.cn/20201119234719587.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

然后打开 `Environment` ，进行选择 `Skybox Material` 中的 `Default-Diffuse`

<img src="https://img-blog.csdnimg.cn/20201119234824661.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

这样即可将背景调为黑色，显示效果如下：

<img src="https://img-blog.csdnimg.cn/20201119234950369.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

然后创建一个空对象 `ParticleHalo` 粒子光环，然后在这个空对象上添加粒子系统

<img src="https://img-blog.csdnimg.cn/20201119235131239.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

然后需要挂载一个代码 `ParticleHalo` 在上面，控制粒子系统的形状等各种信息，代码的具体介绍在下一部分

### 代码实现

- **成员变量**：

  ```c#
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
  ```

- `SetPos()`：初始化栗子的位置，使得粒子集中在平均半径附近

  ```c#
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
  ```

- `Start()`：初始化粒子数组和粒子系统，设置粒子的位置：

  ```c#
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
  ```

- `Update()`：保证角度在360度以内；控制粒子半径变化；确保粒子在规定范围内运动；设置粒子数组位置

  ```c#
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
  ```

## 实验总结

通过本次实验了解了粒子系统的创建，以及各个属性的作用。并且能够运用粒子系统制作出很多炫酷的效果。