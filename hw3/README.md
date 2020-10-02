## 编程实践 (二选一)

- **牧师与魔鬼 动作分离版**
  - **【2019开始的新要求】：设计一个裁判类，当游戏达到结束条件时，通知场景控制器游戏结束**
- **奖励关卡的游戏原型设计**
  - **阅读天蚕土豆小说《大主宰》[第 975-981 章](https://www.doupobook.com/dazhuzai/4768.html)，这段描述了男主离开九幽族到神兽之原的途中在太空中穿梭的过程。**
  - **用基本图形描述游戏中的对象（美工不是考虑的问题），你需要关注以下问题**
    1. **游戏世界对象和元素**
    2. **基本玩法与挑战**
    3. **管理游戏物体的运动**
  - **必须用一段视频展现成果**

### 牧师与魔鬼 动作分离版

#### 说明

本次游戏是对上一次游戏的更新，游戏的玩法并没有改变，只是改变了实现的方式，这次选择用动作控制器来控制各个对象的动作。此外，这次游戏还增加了背景图，美化了背景。

#### 游戏运行说明

直接将hw3中的 `assets` 文件夹下载下来然后用 unity hub 打开，加载场景后即可成功运行，或者创建一个新的项目，然后将此文件夹覆盖新创建的 `assets` 文件夹，加载场景后即可成功运行  
 
#### 游戏截图和视频

<img src="https://img-blog.csdnimg.cn/20201002212926103.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom: 33%;" />

<img src="https://img-blog.csdnimg.cn/2020100221300936.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

<img src="https://img-blog.csdnimg.cn/20201002213127833.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />



[视频地址](https://www.bilibili.com/video/BV1r54y1k73m)

#### 博客地址

[传送门](https://blog.csdn.net/qq_43267773/article/details/108905141)

#### 游戏Assets结构

本次 `Assets` 较上次相比较，多了个 `Fantasy Skybox` 文件夹，用来存储整个天空的背景，并且脚本文件夹中多了个动作控制器的文件夹其中包含了所有新添的关于动作控制器的代码文件

<img src="https://img-blog.csdnimg.cn/20201002213502103.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:50%;" />

#### 动作控制器实现

首先上设计图：

<img src="https://pmlpml.gitee.io/game-unity/post/images/ch04/ch04-oo-design.png" style="zoom:50%;" />

设计思路如下：

- 通过门面模式（控制器模式）输出组合好的几个动作，共原来程序调用。
  - 好处，动作如何组合变成动作模块内部的事务
  - 这个门面就是 CCActionManager
- 通过组合模式实现动作组合，按组合模式设计方法
  - 必须有一个抽象事物表示该类事物的共性，例如 SSAction，表示动作，不管是基本动作或是组合后动作
  - 基本动作，用户设计的基本动作类。 例如：CCMoveToAction
  - 组合动作，由（基本或组合）动作组合的类。例如：CCSequenceAction
- 接口回调（函数回调）实现管理者与被管理者解耦
  - 如组合对象实现一个事件抽象接口（ISSCallback），作为监听器（listener）监听子动作的事件
  - 被组合对象使用监听器传递消息给管理者。至于管理者如何处理就是实现这个监听器的人说了算了
  - 例如：每个学生做完作业通过邮箱发消息给学委，学委是谁，如何处理，学生就不用操心了
- 通过模板方法，让使用者减少对动作管理过程细节的要求
  - SSActionManager 作为 CCActionManager 基类

本次实验的代码基本上都是基于老师给的框架(代码图)实现的，[网页地址](https://pmlpml.gitee.io/game-unity/post/04-gameobject-and-graphics/#6作业与练习)，所以设计起来比较简单，比上一次的工作量也少了很多，也需要对之前的代码进行修改，接下来详细的说明一下各个类的关系和作用以及对之前代码的修改

**修改：**

- 直接删去 `Moving` 类，由于本次实验会实现动作控制器，所以并不需要此类，所有的动作都在动作控制器中执行即可，并且注释掉在 `BoadtController` 和 `RoleController` 中关于用了此类变量和函数的代码

- `BoatController` 类需要增加两个新的函数，分别是获取目的地的函数`getDest()` 和 `move()` 判断移动方向的函数

  ```c#
  public Vector3 getDest() {
    if (st_pos == -1) return sPosition;
    else return ePosition;
  }
  
  public void move() {
    if (st_pos == -1) st_pos = 1;
    else st_pos = -1;
  }
  ```

- `RoleController` 类也需要新增两个函数 `getPos()` 和 `getGameobj()`，分别用来获取对象的位置信息和游戏对象

 ```c#
public Vector3 getPos() {
	return this.obj.transform.position;
}

public GameObject getGameobj() {
	return this.obj;
}
 ```

- `FirstController` 类就是需要将新增的函数取代之前 `Moving` 类中的函数，还需要增加一个私有变量 `FirstActionController` 用来调用动作控制类

**新增的动作控制类：**

- `BaseAction` 类是动作基类，动作管理者也是通过此类来管理动作的，这里使用 `virtual` 申明虚方法，通过重写实现多态。这样继承者就明确使用 Start 和 Update 编程游戏对象行为，利用接口 `Callback` 实则消息通知，避免与动作管理者直接依赖。该类也保存了动作作用的对象和这个对象的 `Transform` 组件

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动作基类
public class BaseAction : ScriptableObject{

    public bool enable = true;
    public bool destroy = false;

    public GameObject gameObject { get; set; }
    public Transform transform { get; set; }
    public Callback callback { get; set; }

    public virtual void Start(){
        throw new System.NotImplementedException();
    }

    public virtual void Update(){
        throw new System.NotImplementedException();
    }
}
```

- `ActionManager` 类，动作管理基类，这是对动作对象管理器的基类，实现了所有动作的基本管理；创建 MonoBehaiviour 管理一个动作集合，动作做完自动回收动作；有一个动作字典；update 演示了由添加、删除等复杂集合对象的使用；提供了添加新动作的方法 RunAction。该方法把游戏对象与动作绑定，并绑定该动作事件的消息接收者；执行该动作的 Start 方法

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动作管理基类
public class ActionManager: MonoBehaviour, Callback {
    private Dictionary<int, BaseAction> actions = new Dictionary<int, BaseAction>();
    private List<BaseAction> waitingAdd = new List<BaseAction>();
    private List<int> waitingDelete = new List<int>();

    protected void Update() {
        foreach(BaseAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        foreach(KeyValuePair<int, BaseAction> kv in actions) {
            BaseAction ac = kv.Value;
            if (ac.destroy) {
                waitingDelete.Add(ac.GetInstanceID());
            } else if (ac.enable) {
                ac.Update();
            }
        }

        foreach(int key in waitingDelete) {
            BaseAction ac = actions[key]; actions.Remove(key); DestroyObject(ac);
        }
        waitingDelete.Clear();
    }

    public void RunAction(GameObject gameObject, BaseAction action, Callback callback) {
        action.gameObject = gameObject;
        action.transform = gameObject.transform;
        action.callback = callback;
        waitingAdd.Add(action);
        action.Start();
    }

    public void ActionEvent(BaseAction source) {}

}
```



- `Callback` 类动作时间接口，接口作为接受通知对象的抽象类型,事件类型定义，使用了 **枚举变量**;定义了事件处理接口，所有事件管理者都必须实现这个接口，来实现事件调度。所以，组合事件需要实现它，事件管理器也必须实现它。;这里展示了语言函数 **默认参数** 的写法。

  ```c#
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  
  // 监听动作
  public interface Callback {
      void ActionEvent(BaseAction source);
  }
  ```

- `MoveToAction` 类是简单动作的实现，实现具体动作，讲一个物体移动到目标位置，并通知任务完成，当动作完成时会被自动销毁

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 简单的动作类
public class MoveToAction : BaseAction
{
    public Vector3 target;
    public float speed;

    private MoveToAction(){}
    public static MoveToAction getAction(Vector3 target, float speed) {
        MoveToAction action = ScriptableObject.CreateInstance<MoveToAction>();
        action.target = target;
        action.speed = speed;
        return action;
    }

    public override void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed*Time.deltaTime);
        if (this.transform.position == target) {
            this.destroy = true;
            this.callback.ActionEvent(this);
        }
    }

    public override void Start() {}

}
```

- `SequenceAction` 类顺序动作组合类的实现，实现一个动作组合序列，顺序播放动作，这让动作组合继承抽象动机，能够被进一步组合；实现回调接受，能接受被组合动作的时间。创建一个动作顺序执行序列，-1代表无限循环，1代表执行一次，start代表开始动作；`Update`方法执行执行当前动作;`SSActionEvent` 收到当前动作执行完成，推下一个动作，如果完成一次循环，减次数。如完成，通知该动作的管理者;`Start` 执行动作前，为每个动作注入当前动作游戏对象，并将自己作为动作事件的接收者;`OnDestory` 如果自己被注销，应该释放自己管理的动作。

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 顺序动作组合类
public class SequenceAction: BaseAction, Callback {
    public List<BaseAction> sequence;
    public int repeat = 1; // -1:重复 1:一次
    public int start = 0;

    public static SequenceAction getAction(int repeat, int start, List<BaseAction> sequence) {
        SequenceAction action = ScriptableObject.CreateInstance<SequenceAction>();
        action.sequence = sequence;
        action.repeat = repeat;
        action.start = start;
        return action;
    }

    public override void Update() {
        if (sequence.Count == 0)return;
        if (start < sequence.Count) {
            sequence[start].Update();
        }
    }

    public void ActionEvent(BaseAction source) {
        source.destroy = false;
        this.start++;
        if (this.start >= sequence.Count) {
            this.start = 0;
            if (repeat > 0) repeat--;
            if (repeat == 0) { this.destroy = true; this.callback.ActionEvent(this); }
        }
    }

    public override void Start() {
        foreach(BaseAction action in sequence) {
            action.gameObject = this.gameObject;
            action.transform = this.transform;
            action.callback = this;
            action.Start();
        }
    }

    void OnDestroy() {
        foreach(BaseAction action in sequence) DestroyObject(action);
    }
}
```

- `FirstActionController` 类是 `ActionManager` 的子类，并且由 `FirstController` 来管理他的动作，封装该类可以使得调用起来更加方便简洁

  ```c#
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  
  // 动作总控制器
  public class FirstActionController:ActionManager {
  	public void moveBoat(BoatController boat) {
  		MoveToAction action = MoveToAction.getAction(boat.getDest(), boat.speed);
  		this.RunAction(boat.getGameobj(), action, this);
  	}
  
  	public void moveCharacter(RoleController r, Vector3 d) {
  		Vector3 cur = r.getPos();
  		Vector3 mid = cur;
  		if (d.y > cur.y) mid.y = d.y;
  		else mid.x = d.x;
  
  		BaseAction act1 = MoveToAction.getAction(mid, r.speed);
  		BaseAction act2 = MoveToAction.getAction(d, r.speed);
  		BaseAction seq = SequenceAction.getAction(1, 0, new List<BaseAction>{act1, act2});
  		this.RunAction(r.getGameobj(), seq, this);
  	}
  }
  ```