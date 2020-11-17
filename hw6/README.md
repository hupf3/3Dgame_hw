- [模型与动画](#模型与动画)
  - [智能巡逻兵](#智能巡逻兵)
  - [游戏设计](#游戏设计)
    - [游戏说明](#游戏说明)
      - [游戏玩法](#游戏玩法)
      - [规则说明](#规则说明)
    - [游戏截图和视频](#游戏截图和视频)
    - [博客地址](#博客地址)
    - [游戏运行说明](#游戏运行说明)
    - [游戏 Assets 结构](#游戏-assets-结构)
    - [要求实现](#要求实现)
    - [代码实现](#代码实现)
      - [AreaControl](#areacontrol)
      - [CCActionManager](#ccactionmanager)
      - [CCFollow](#ccfollow)
      - [CCMoveToAction](#ccmovetoaction)
      - [CrystalControl](#crystalcontrol)
      - [Factory](#factory)
      - [FirstSceneController](#firstscenecontroller)
      - [GameEventManager](#gameeventmanager)
      - [Interface](#interface)
      - [Patrol](#patrol)
      - [PlayerControl](#playercontrol)
      - [Singleton](#singleton)
      - [SSAction](#ssaction)
      - [SSActionManager](#ssactionmanager)
      - [SSDirector](#ssdirector)
      - [View](#view)
  - [实验总结](#实验总结)

# 模型与动画

## 智能巡逻兵

- 提交要求：
- 游戏设计要求：
  - 创建一个地图和若干巡逻兵(使用动画)；
  - 每个巡逻兵走一个3~5个边的凸多边型，位置数据是相对地址。即每次确定下一个目标位置，用自己当前位置为原点计算；
  - 巡逻兵碰撞到障碍物，则会自动选下一个点为目标；
  - 巡逻兵在设定范围内感知到玩家，会自动追击玩家；
  - 失去玩家目标后，继续巡逻；
  - 计分：玩家每次甩掉一个巡逻兵计一分，与巡逻兵碰撞游戏结束；
- 程序设计要求：
  - 必须使用订阅与发布模式传消息
    - subject：OnLostGoal
    - Publisher: ?
    - Subscriber: ?
  - 工厂模式生产巡逻兵
- 友善提示1：生成 3~5个边的凸多边型
  - 随机生成矩形
  - 在矩形每个边上随机找点，可得到 3 - 4 的凸多边型
  - 5 ?
- 友善提示2：参考以前博客，给出自己新玩法

## 游戏设计

### 游戏说明

#### 游戏玩法

玩家可以通过键盘上的方向键或者 `wsad` 控制人物的移动，游戏场景是人物控制的第一视角，地图中会散落一些巡逻兵，碰到巡逻兵就会死亡，我们的目标是尽可能多的获取水晶

#### 规则说明

游戏由玩家和若干个巡逻兵和水晶构成，每当玩家进入一个新的领域，该部分的巡逻兵就会监测到，然后跟踪玩家，玩家要尽可能地躲避跟踪来的巡逻兵，然后获取水晶，当获取5个水晶后游戏即为胜利；若被巡逻兵逮住就会游戏失败，可以重新开始。

### 游戏截图和视频

游戏的是第一人称视角，游戏的界面有左上角的时间，分数每躲开一个巡逻兵便加一以及收集到的宝石，每获取一个宝石，便加一；游戏胜利时会有退出游戏的按钮；游戏失败时，会有重新开始的按钮

<img src="https://img-blog.csdnimg.cn/20201117114436307.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

<img src="https://img-blog.csdnimg.cn/20201117114605360.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

<img src="https://img-blog.csdnimg.cn/20201117114703564.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

游戏的运行视频：[传送门](https://www.bilibili.com/video/BV1cZ4y157rz)

### 博客地址

[传送门](https://blog.csdn.net/qq_43267773/article/details/109740352)

### 游戏运行说明

将 `Assets` 文件夹下载到本地，然后直接通过unity打开该文件即可成功运行，或者新建个项目，用该 `Assets` 文件夹覆盖原有的，打开后即可正常运行

### 游戏 Assets 结构

项目的 `Assets` 结构如下所示：

<img src="https://img-blog.csdnimg.cn/20201117125547285.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- `AxeyWorks`：该目录存储了本次项目的地图信息，该地图我是参考的学长的项目文件进行了一些修改，成为了本次游戏的地图场景

- `Fantasy Skybox FREE`：该目录存储了本次实验的天空的颜色，我设置的天空是蓝色的，这也使得游戏界面看起来更加美观

- `Resources\Prefab`：本目录结构是用于存放项目的预制资源，本游戏设计的资源如下：

  <img src="https://img-blog.csdnimg.cn/20201117130017611.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  - `Camera` ：是本次实验的相机，用于查看场景信息，本次游戏设计的是第一视角，所以我将相机放到了 `Player` 上面实现了第一人称视角，并且在 `Camera `中也需要添加上代码组件实现场景的构建

    <img src="https://img-blog.csdnimg.cn/20201117130456209.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

    <img src="https://img-blog.csdnimg.cn/20201117130423397.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  - `Ground`：是本次游戏设计的地面，设计的方法是参照了往届制作的作品，包含了围栏和水晶等信息：

    <img src="https://img-blog.csdnimg.cn/20201117130658415.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  - `Patrol` ：巡逻兵，模型是在网上的资源找到：

    <img src="https://img-blog.csdnimg.cn/20201117131051622.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

    在项目中，需要为模型增加 `Rigidbody` 和 `Box Collider` 的信息，使其实现碰撞，并且需要挂载代码 `Player Control` 实现对巡逻兵的控制：

    <img src="https://img-blog.csdnimg.cn/20201117131003326.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" /> 

  - `PatrolAnimator`：动作控制器，实现了巡逻兵的动作的设置，以及状态转移

    <img src="https://img-blog.csdnimg.cn/20201117131349932.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

    该人物主要有三种状态，普通的移进状态对应了图中的 `Idle` ，看到玩家后进入到 `Run` ，接触到玩家后实现攻击 `Attack`，之间的关系正如上图所示，所有的动作都是拖入了网上的资源

    <img src="https://img-blog.csdnimg.cn/20201117131623252.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

    动作控制器实现后应当拖入到巡逻兵的组件中：

    <img src="https://img-blog.csdnimg.cn/20201117131653349.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  - `Player`：玩家即我们需要控制的模型，该模型来自于网上的资源

    <img src="https://img-blog.csdnimg.cn/20201117131911267.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

    在项目中，需要为模型增加 `Rigidbody` 和 `Box Collider` 的信息，使其实现碰撞，并且需要挂载代码 `Player Control` 实现对玩家的控制：

    <img src="https://img-blog.csdnimg.cn/20201117131949819.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

    因为是第一视角，所以需要在玩家上挂载一个相机，然后就可以实现：

    <img src="https://img-blog.csdnimg.cn/20201117152025137.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

  - `PlayerAnimator`：动作控制器，实现了玩家的动作的设置，以及状态转移

    <img src="https://img-blog.csdnimg.cn/20201117132140895.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

    该人物主要有三种状态，普通的移进状态对应了图中的 `idle` ，方向键控制玩家后进入到 `run` ，接触到巡逻兵后死亡 `die`，之间的关系正如上图所示，所有的动作都是拖入了网上的资源：

    <img src="https://img-blog.csdnimg.cn/20201117132304726.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

    动作控制器实现后应当拖入到巡逻兵的组件中：

    <img src="https://img-blog.csdnimg.cn/20201117132352336.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- `RPG Monster Duo PBR Polyart`：是在网上下载的本次游戏的人物模型，动作等信息都在其中

- `Scenes`：本次游戏的场景，点击该场景进行运行即可成功开始游戏

  <img src="https://img-blog.csdnimg.cn/20201117132554853.png#pic_center" alt="在这里插入图片描述" style="zoom:50%;" />

  在 `Main` 中挂载了 `FirstSceneController` 代码

- `Script`：存储本次游戏的代码文件，实现了订阅与发布模式传消息，工厂模式生产巡逻兵

  <img src="https://img-blog.csdnimg.cn/20201117132724458.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom: 33%;" />

### 要求实现

本次实验的游戏设计要求，会在代码实现的部分进行详细说明；程序设计要求，在上面的代码结构中已经提现，实现了订阅与发布模式传消息，工厂模式生产巡逻兵

**新功能实现**：

- 实现了第一人称进行游戏
- 实现了游戏胜利条件，捡拾水晶
- 实现了背景音乐的加入

### 代码实现

#### AreaControl

该代码文件实现了对游戏中区域的控制，该游戏的区域被栅栏分成了九宫格的形状，并且标记了在玩家进入每个九宫格的时候位置。

该文件需要挂载到预制 `Ground` 中的各个区域中：

<img src="https://img-blog.csdnimg.cn/20201117150735729.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

<img src="https://img-blog.csdnimg.cn/20201117150849854.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 九宫格区域控制 √
public class AreaControl : MonoBehaviour {
    public int block = 0;
    FirstSceneController sc;

    private void Start () {
        sc = SSDirector.getInstance ().currentScenceController as FirstSceneController;
    }

    // 玩家进入需要进行标记
    void OnTriggerEnter (Collider c) {
        if (c.gameObject.tag == "Player") {
            sc.SetPos (block);
            GameEventManager.Instance.PlayerEscape ();
        }
    }
}
```

#### CCActionManager

该代码文件实现了动作的组合，首先有个 `Dictionary` 结构的 `actionlist` 存储了动作的序列。该文件总共实现了以下的函数：

- `Follow` ：巡逻兵跟随玩家
- `GoRoute`：设计巡逻兵行走的位置
- `GetPos` ：每一阶段获取巡逻兵该行走的新的位置

以上函数实现了巡逻兵的运动图形、目标跟踪、丢失目标进行巡逻

```c#
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

// 动作组合 √
public class CCActionManager : SSActionManager, SSActionCallback {
    // 动作序列
    Dictionary<int, CCMoveToAction> actionList = new Dictionary<int, CCMoveToAction> ();

    // 巡逻兵跟随玩家
    public void Follow (GameObject p, GameObject player) {
        if (actionList.ContainsKey (p.GetComponent<Patrol> ().block)) actionList[p.GetComponent<Patrol> ().block].destroy = true;
        CCFollow action = CCFollow.getAction (player, 0.8f);
        RunAction (p.gameObject, action, this);
    }

    // 行走路线
    public void GoRoute (GameObject p) {
        CCMoveToAction action = CCMoveToAction.getAction (p.GetComponent<Patrol> ().block, 0.6f, GetPos (p));
        actionList.Add (p.GetComponent<Patrol> ().block, action);
        RunAction (p.gameObject, action, this);
    }

    // 行走中获取新的行走地点
    private Vector3 GetPos (GameObject p) {
        Vector3 pos = p.transform.position;
        int block = p.GetComponent<Patrol> ().block;

        // 获取新的移动方向
        float x1 = -5.0f + (block % 3) * 8.7f; float x2 = -14.1f + (block % 3) * 10.3f;
        float z1 = 12.3f - (block / 3) * 8.95f; float z2 = 4.9f - (block / 3) * 9.54f;
        
        Vector3 vec = new Vector3 (Random.Range (-2f, 2f), 0, Random.Range (-2f, 2f)); Vector3 nextPos = pos + vec;

        while (!(nextPos.x < x1 && nextPos.x > x2 && nextPos.z < z1 && nextPos.z > z2)) {
            vec = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
            nextPos = pos + vec;
        }
        
        return nextPos;
    }

    // 初始化清空
    public void InitClear () {
        foreach (CCMoveToAction a in actionList.Values) a.destroy = true;
        actionList.Clear ();
    }

    // 回调函数
    public void SSActionCallback (SSAction source) {
        if (actionList.ContainsKey (source.gameObject.GetComponent<Patrol> ().block)) actionList.Remove (source.gameObject.GetComponent<Patrol> ().block);
        GoRoute (source.gameObject);
    }
}
```

#### CCFollow

该代码文件实现了跟随动作的设置，设计了追到玩家之后进行的动作：

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 跟随动作 √
public class CCFollow : SSAction {
    public GameObject v; // 目标
    public float speed; // 移动速度

    private CCFollow () {}
    public override void Start () {}

    public static CCFollow getAction (GameObject v, float speed) {
        CCFollow action = ScriptableObject.CreateInstance<CCFollow> ();
        action.v = v; action.speed = speed;
        return action;
    }

    public override void Update () {
        this.transform.position = Vector3.MoveTowards (transform.position, v.transform.position, speed * Time.deltaTime);
        Quaternion rotation = Quaternion.LookRotation (v.transform.position - gameObject.transform.position, Vector3.up);
        gameObject.transform.rotation = rotation;

        // 追到了玩家
        if (gameObject.GetComponent<Patrol> ().status == false || transform.position == v.transform.position) {
            destroy = true;
            CallBack.SSActionCallback (this);
        }
    }
}
```

#### CCMoveToAction

该代码文件是简单动作的实现，讲一个物体移动到指定的位置，并通知任务完成：

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 简单动作实现，将一个物体移动到指定位置，并通知任务完成 √
public class CCMoveToAction : SSAction {
    public Vector3 target; // 位置
    public float speed;
    public int block; // 对应于地图中的位置

    private CCMoveToAction () { }

    // 获取动作
    public static CCMoveToAction getAction (int b, float v, Vector3 p) {
        CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction> ();
        action.target = p;
        action.speed = v;
        action.block = b;
        return action;
    }

    public override void Update () {
        if (this.transform.position == target) {
            destroy = true;
            CallBack.SSActionCallback (this);
        }
        this.transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
    }

    public override void Start () {
        // 转变方向
        Quaternion rotation = Quaternion.LookRotation (target - transform.position, Vector3.up);
        transform.rotation = rotation;
    }
}
```

#### CrystalControl

该代码文件实现了对水晶的控制，当玩家与水晶碰撞时，水晶会消失，并且收集到的水晶数 +1。

该文件需要挂载到 `Ground` 预制中的水晶：

<img src="https://img-blog.csdnimg.cn/20201117150717654.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />



<img src="https://img-blog.csdnimg.cn/20201117150702759.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 水晶控制 √
public class CrystalControl : MonoBehaviour {
    // 当玩家与水晶相撞
    void OnCollisionEnter (Collision c) {
        SSDirector director;
        if (c.gameObject.tag == "Player") {
            Destroy (this.gameObject);
            director = SSDirector.getInstance ();
            int i = director.currentScenceController.GetCrystal ();
            i = i + 1;
            director.currentScenceController.setCrystal (i);
        }
    }
}
```

#### Factory

该代码文件实现了巡逻兵的制造工厂，该代码文件实现了工厂模式，实现了初始化巡逻兵的状态，位置等信息：

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 巡逻兵制造工厂 √
public class Factory {
    public static Factory fa = new Factory ();
    // 使用过的巡逻兵的位置和对象
    private Dictionary<int, GameObject> used = new Dictionary<int, GameObject> ();

    private Factory () { }

    int[] pos_x = {-5, 0, 7}; int[] pos_z = {7, 3, -6};
    public Dictionary<int, GameObject> GetPatrol () {
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                GameObject patrol = GameObject.Instantiate<GameObject> (Resources.Load<GameObject> ("Prefabs/Patrol"));
                // 设置属性
                patrol.AddComponent<Patrol> ();
                patrol.transform.position = new Vector3 (pos_x[j], 0, pos_z[i]);
                patrol.GetComponent<Patrol> ().block = i * 3 + j;
                patrol.SetActive (true);
                used.Add (i * 3 + j, patrol);
            }
        }
        return used;
    }

    // 恢复位置
    public void InitPatrol () {
        for (int i = 0; i < 3; i++) 
            for (int j = 0; j < 3; j++) 
                used[i * 3 + j].transform.position = new Vector3 (pos_x[j], 0, pos_z[i]);
    }
}
```

#### FirstSceneController

该代码文件实现了游戏的总控制器，主要实现了以下的函数：

- `AddScore`：每当甩掉一个巡逻兵的时候，即玩家从一个九宫格进入到另一个九宫格，分数会➕1
- `GameOver`：游戏结束时场景的销毁，以及人物模型的状态
- `SetPos`：设置玩家的位置
- `MovePlayer`：控制玩家的移动

除了以上的函数，还实现了一些变量的初始化，以及一些简单的 Get 函数

```c#
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
```

#### GameEventManager

该代码文件实现了游戏时间的管理，实现了玩家逃脱的时间，以及游戏结束玩家被捕的事件，以及记分的事件

```c#
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
```

#### Interface

该代码文件实现了动作时间接口的命名空间，定义了一些游戏的事件的接口：

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动作事件接口定义 √
namespace Interfaces {
    public interface ISceneController {
        void setCrystal (int c);
        int GetCrystal ();
        void LoadResources ();
    }

    public interface UserAction {
        int GetScore ();
        void Restart ();
        bool GetGameState ();
        void MovePlayer (float moveX, float moveZ);
    }

    public enum SSActionEventType : int { Started, Completed }

    public interface SSActionCallback {
        void SSActionCallback (SSAction s);
    }
}
```

#### Patrol

该代码文件实现了巡逻兵的设计，实现了设置了巡逻兵的位置，以及判断巡逻兵的状态是否为追逐玩家，并且设计了旋转方式：

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 巡逻兵 √
public class Patrol : MonoBehaviour {
    public int block; // 巡逻兵位置
    public bool status = false; // 判断巡逻兵的状态是否为追逐玩家

    private void Start () {
        // 冻结
        if (gameObject.GetComponent<Rigidbody> ()) gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
    }

    // 旋转方式
    void Update () {
        if (this.gameObject.transform.localEulerAngles.x != 0 || gameObject.transform.localEulerAngles.z != 0)
            gameObject.transform.localEulerAngles = new Vector3 (0, gameObject.transform.localEulerAngles.y, 0);
        
        if (gameObject.transform.position.y != 0)
            gameObject.transform.position = new Vector3 (gameObject.transform.position.x, 0, gameObject.transform.position.z);
    }
}
```

#### PlayerControl

该代码文件实现了玩家的控制，当玩家与侦查兵相撞时，游戏结束。

该文件需要挂载到巡逻兵的组件上：

<img src="https://img-blog.csdnimg.cn/2020111715050596.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家控制 √
public class PlayerControl : MonoBehaviour {
    // 玩家与侦察兵相撞，游戏结束
    void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "Player") GameEventManager.Instance.PlayerArrest ();
        
    }
}
```

#### Singleton

该代码文件实现了创建了一个对象的实例化：

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 创建一个对象的实例 √
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    protected static T instance;
    public static T Instance {
        get {
            if (instance == null) {
                instance = (T) FindObjectOfType (typeof (T));
                if (instance == null) {
                    Debug.LogError ("An instance of " + typeof (T) + " is needed in the scene, but there is none.  ");
                }
            }
            return instance;
        }
    }
}
```

#### SSAction

该代码文件实现了游戏的动作基类：

```c#
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

// 动作基类 √
public class SSAction : ScriptableObject {
    public bool enable = true;
    public bool destroy = false;

    public GameObject gameObject;
    public Transform transform;
    public SSActionCallback CallBack;

    public virtual void Start () {
        throw new System.NotImplementedException ();
    }

    public virtual void Update () {
        throw new System.NotImplementedException ();
    }
}
```

#### SSActionManager

该代码文件实现了动作管理器的基类：

```c#
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

// 动作对象管理器的基类 √
public class SSActionManager : MonoBehaviour {
    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction> ();
    private List<SSAction> waitingToAdd = new List<SSAction> ();
    private List<int> watingToDelete = new List<int> ();

    protected void Update () {
        foreach (SSAction ac in waitingToAdd) {
            actions[ac.GetInstanceID ()] = ac;
        }
        waitingToAdd.Clear ();

        foreach (KeyValuePair<int, SSAction> kv in actions) {
            SSAction ac = kv.Value;
            if (ac.destroy) {
                watingToDelete.Add (ac.GetInstanceID ());
            } else if (ac.enable) {
                ac.Update ();
            }
        }

        foreach (int key in watingToDelete) {
            SSAction ac = actions[key];
            actions.Remove (key);
            Destroy (ac);
        }
        watingToDelete.Clear ();
    }

    public void RunAction (GameObject gameObject, SSAction action, SSActionCallback ICallBack) {
        action.gameObject = gameObject;
        action.transform = gameObject.transform;
        action.CallBack = ICallBack;
        waitingToAdd.Add (action);
        action.Start ();
    }
}
```

#### SSDirector

该代码文件实现了游戏的总导演，并且手动设置游戏的帧率信息：

```c#
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

// 总导演 √
public class SSDirector : System.Object {
    private static SSDirector _instance;

    public ISceneController currentScenceController { get; set; }
    public bool running { get; set; }

    public static SSDirector getInstance () {
        if (_instance == null) _instance = new SSDirector ();
        return _instance;
    }

    // 手动设置游戏帧率
    public int getFPS () { return Application.targetFrameRate; }
    public void setFPS (int fps) { Application.targetFrameRate = fps; }
}
```

#### View

该代码文件实现了场景的构建，并且获取玩家移动信息，该场景主要包括了时间，分数，以及收集到的宝石，并且定义了游戏的规则，获取5个宝石游戏即为成功，当游戏胜利时，可以退出游戏，当游戏失败时继续游戏。

该文件需要挂载到相机上实现场景的加载：

<img src="https://img-blog.csdnimg.cn/20201117150435149.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

```c#
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

// 视图
public class View : MonoBehaviour {
    UserAction userAction;
    ISceneController iSceneController;
    Factory fa;
    bool state = false;
    bool win = false; // 判断是否获胜
    float startTime; // 开始时间
    
    private GUIStyle font = new GUIStyle(); // 设置文字
    private GUIStyle digit = new GUIStyle(); // 设置数字
    
    

    void Start () {
        font.fontSize = 20; font.normal.textColor = Color.blue;
        digit.fontSize = 20; digit.normal.textColor = Color.red;

        userAction = SSDirector.getInstance ().currentScenceController as UserAction;
        iSceneController = SSDirector.getInstance ().currentScenceController as ISceneController;
        startTime = Time.time;
    }

    // 控制玩家移动
    private void Update () {
        float moveX = Input.GetAxis ("Horizontal");
        float moveZ = Input.GetAxis ("Vertical");
        userAction.MovePlayer (moveX, moveZ);
    }

    private void OnGUI () {
        if (!state) startTime = Time.time;
        GUI.Label(new Rect(10, 10, 200, 200), "时间: ", font);
        GUI.Label(new Rect(72, 10, 200, 200), "" + ((int) (Time.time - startTime)).ToString (), digit);

        GUI.Label(new Rect(10, 40, 200, 200), "分数: ", font);
        GUI.Label(new Rect(75, 40, 200, 200), "" + userAction.GetScore().ToString (), digit); 

        GUI.Label(new Rect(10, 70, 200, 200), "已采集到的宝石: ", font);
        GUI.Label(new Rect(75, 70, 200, 200), "                " + iSceneController.GetCrystal().ToString (), digit);

        if (state){
            if (!userAction.GetGameState ()) state = false;
            // 取到5个宝石即为成功
            if (iSceneController.GetCrystal () >= 5){
                win = true;
                state = false;
            }
        } else{
            if (win){
                GUIStyle fontStyle = new GUIStyle ();
                fontStyle.alignment = TextAnchor.MiddleCenter;
                fontStyle.fontSize = 25;
                fontStyle.normal.textColor = Color.white;
                GUI.Label (new Rect (Screen.width / 2 - 25, Screen.height / 2 - 80, 100, 50), "获胜!", fontStyle);
                fa = Factory.fa;
                fa.InitPatrol ();

                if (GUI.Button (new Rect (Screen.width / 2 - 30, Screen.height / 2 - 30, 100, 50), "退出")){
                    UnityEditor.EditorApplication.isPlaying = false;
                }
            } else if (GUI.Button (new Rect (Screen.width / 2 - 30, Screen.height / 2 - 30, 100, 50), "重新开始")) {
                state = true;
                iSceneController.LoadResources ();
                startTime = Time.time;
                userAction.Restart ();
            }
        }
    }
}
```

## 实验总结

本次实验的工作量较大，需要设计的东西很多，学会了动画的设置，以及订阅与发布模式来传递信息，并且能够将多种设计模式融合在一起实现，收获很多。