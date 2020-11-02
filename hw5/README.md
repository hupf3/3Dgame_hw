# 物理系统与碰撞

## 改进飞碟（Hit UFO）游戏

- 游戏内容要求：
  1. 按 *adapter模式* 设计图修改飞碟游戏
  2. 使它同时支持物理运动与运动学（变换）运动

## 游戏改进

### Adapter 模式

个人理解 Adapter 模式即适配器模式是把一个类的接口变换成客户端所期待的另一种接口。无论哪种适配器，宗旨都是：保留现有类所提供的服务，向客户提供接口，以满足客户的期望。即在不改变原有系统的基础上，提供新的接口服务。

**适用场景**：使用一个已经存在的类，而它的接口不符合你的需求，创建一个可以复用的类，该类可以与其他不相关的类或不可预见的类（即那些接口可能不一定兼容的类）协同工作。

### 游戏说明

#### 游戏玩法

玩家通过鼠标点击界面中随机出现的飞碟来获取积分，游戏界面会有四个按钮，一个是 `pause` 按钮，可以暂停游戏，一个是 `restart` 按钮可以重新开始游戏，一个是 `next Round` 按钮是进入下一个回合，最后一个是 `change Mode ` 按钮是更换游戏模式

#### 规则说明

游戏中会有三种不同的飞碟，分别是红色，蓝色，绿色的飞碟，不同的飞碟大小会有不同，因此点击到不同的飞碟得分也会不同，红色飞碟最小，分数为3；蓝色飞碟大小适中，分数为2；绿色飞碟最大，分数为1.

游戏会分为5个回合(round)，每个回合中会有10次 trial ，每次 trial 出现的飞碟的数量，个数，种类，角速度，速度都是不同的，且每次 trial 仅持续 3 秒，意味着每回合的时间为30秒，30秒过后就是全新的回合。随着回合数的增加飞碟运行的速度会有提高，游戏的整体难度会变高。当第五回合游戏结束后，会显示 `Game Over` 游戏结束。

### 改进说明

本次实验将上次设计的打飞碟游戏进行了升级，使用了 Adapter 模式，为了实现该模式，我将之前的代码改成动作分离的结构。

在新的游戏中多了一个 change model 按钮，这个按钮是为了更换游戏模式的，本游戏包括两种模式，一种是物理运动，另一种是运动学，按此按钮即可完成两种运动模式的转变。一种是给定恒定的速度，一种是给定一个动力，两者在实际的运行视频中差距并不明显，但是在各自的动作控制器中有不同的实现方法。

游戏中的飞碟对象都设置了刚体的属性，可以看到飞碟之间的碰撞

### 游戏截图和视频

<img src="https://img-blog.csdnimg.cn/20201103001540716.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />![在这里插入图片描述](https://img-blog.csdnimg.cn/20201103001605434.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

<img src="https://img-blog.csdnimg.cn/20201103001605434.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

<img src="https://img-blog.csdnimg.cn/20201103001605434.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

游戏的运行视频：[传送门](https://www.bilibili.com/video/BV1bK411G7Sz)

### 博客地址

[传送门]()

### 游戏 Assets 结构

项目的 `Assets` 结构如下图所示：

<img src="https://img-blog.csdnimg.cn/20201013172848931.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- `Materials`：存储了不同的UFO所用的不同的颜色

<img src="https://img-blog.csdnimg.cn/20201013173034303.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

- `Resources/Prefabs`：存储了事先做好的UFO游戏对象，并且存为预制，游戏中的对象需要设置成钢体

<img src="https://img-blog.csdnimg.cn/20201013173336503.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

- `Scenes`：存储了游戏中的场景，直接打开该场景即可正常运行游戏

<img src="https://img-blog.csdnimg.cn/20201013173444349.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

- `Scripts`：游戏项目中的代码，本次项目实现是基于MVC架构和动作分离的，并且使用了工厂模式和 Adapter 模式进行管理

<img src="https://img-blog.csdnimg.cn/20201103002009906.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

### 代码实现

#### IUserAction.cs

定义了一个接口，该接口只有一个函数为 `GameOver()` 代表游戏结束

``` c#
// 游戏结束的接口
public interface IUserAction
{
    void GameOver();
}
```

#### Interface_Model.cs

为 `Model` 类定义了接口，该接口包括三个函数 `LoadResource()`, `NextRound()` 和 `Pause()`，分别代表加载资源的函数，下一个回合的跳转以及暂停游戏的函数，实现如下：

```c#
// 模型的接口
public interface Interface_Model{
    void LoadResources();
    void Pause();
    void NextRound();
}
```

#### Factory.cs

该代码文件为工厂模式来管理UFO的创建以及回收

- 类中的成员变量：`Used_UFO` 和 `Unused_UFO` 变量为两个 `List` 变量，分别存储了屏幕中存在的UFO即使用中的UFO，以及超出摄像机拍摄外即屏幕外的UFO也就是未使用的UFO，`Adapter` 为适配器，`CCActionManager` 分别定义了两种模式下的动作管理器

```C#
public List<GameObject> Used_UFO = new List<GameObject>();
public List<GameObject> Unused_UFO = new List<GameObject>();

public Adapter act_manager;
public CCActionManager1 am1;
public CCActionManager2 am2;
```

- `CreateUFO()`： 函数实现了判断运动的模式，选择相应的动作控制器，创建UFO，由于是用的工厂模式，所以创建的时候需要判断在未使用的UFO的 `List` 是否为空，如果为空则正常选择随机创建一个UFO；如果非空，则需要选择 `Unused_UFO` 中的UFO变为 `Used_UFO` 中的UFO，新UFO的位置以及角速度也是随机生成的

```c#
    // 创建UFO
    public void CreateUFO(){
        if(am1 == null) am1 = GetComponent<CCActionManager1>() as CCActionManager1;
        if(am2 == null) am2 = GetComponent<CCActionManager2>() as CCActionManager2;

        if(mode == 0) act_manager = am1;
        else if(mode == 1) act_manager = am2;

        GameObject obj;
        if (Unused_UFO.Count == 0){
            float num = Random.Range(0f, 3f);
            if (num > 2) obj = Instantiate(Resources.Load("Prefabs/UFO1"), Vector3.zero, Quaternion.identity) as GameObject;
            else if (num > 1) obj = Instantiate(Resources.Load("Prefabs/UFO2"), Vector3.zero, Quaternion.identity) as GameObject;
            else obj = Instantiate(Resources.Load("Prefabs/UFO3"), Vector3.zero, Quaternion.identity) as GameObject;
        }else {
            obj = Unused_UFO[0];
            Unused_UFO.RemoveAt(0);
        }

        // 新的UFO的位置
        float pos_x = Random.Range(-8f, 8f);
        float pos_y = Random.Range(-5f, 5f);
        float pos_z = Random.Range(-2f, 2f);
        obj.transform.position = new Vector3(pos_x, pos_y, 0);
        obj.transform.Rotate(new Vector3(pos_x < 0 ? (-pos_x * 60) : (pos_x * 60), pos_y < 0 ? (-pos_y * 60) : (pos_y * 60), pos_z < 0 ? (-pos_z * 20) : (pos_z * 20)));
        Used_UFO.Add(obj);
    }
```

- `RecycleUFO(GameObject obj)`： 此函数实现了回收游戏对象为 `obj` 的UFO，实现的方法为将 `Unused_UFO` 中的 `obj` 对象移除，并且将该UFO移除界面

```c#
    // 回收UFO
    public void RecycleUFO(GameObject obj){
        for (int i = 0; i < Used_UFO.Count; i++){
            if (Used_UFO.ToArray()[i] == obj) Used_UFO.RemoveAt(i);
        }

        // 移除界面 
        obj.transform.position = new Vector3(100,100,100);
        Unused_UFO.Add(obj);
    }
}
```

#### Singleton.cs

将工厂设计为场景单实例，实现的方法也是参考老师课件中给出的代码结构

```c#
// 场景单实例
public class Singleton : MonoBehaviour{
    protected static Factory instance;

    public static Factory Instance{
        get{
            if (instance == null) instance = (Factory)FindObjectOfType(typeof(Factory));
            return instance;
        }
    }
}
```

#### Controller.cs

该文件为控制器的实现

- 类中的成员变量：`_instance` 获取该 `Controller` 实例，`currentModel` 用来获取当前的 `Model`，`running` 判断当前的游戏是否正常运行

```c#
private static Controller _instance;

public Model currentModel { get; set; }
public bool running{ get; set; } // 判断游戏是否正常运行
```

- `getInstance()`：该函数用于获取当前控制器的实例

```c#
    public static Controller getInstance(){
        if (_instance == null){
            _instance = new Controller();
        }
        return _instance;
    }
```

- `getFPS()`, `setFPS()` ：这两个函数分别是获取当前的游戏帧率以及设置当前的游戏帧率

```c#
    // 手动设置游戏帧率
    public int getFPS(){ return Application.targetFrameRate; }
    public void setFPS(int f){ Application.targetFrameRate = f; }
```

#### Model.cs

该文件是实现了整个游戏模型，并且对游戏的资源进行一定的管理

- 类中的成员变量：`round` 代表了游戏的回合数，`score` 代表玩家所得的分数，`trial` 该回合中进行到了哪，`time` 本回合中游戏进行的时间，`c` 获得控制器的实例

```c#
    public int round;
    public int score;
    public int trial;
    public int time;
    Controller c;

    public Factory fa;
```

- `Pause()`：此函数用来控制游戏的运行和停止

```c#
public void Pause(){ c.running = !c.running; }
```

- `GameOver()`：用来控制游戏的结束，将所有的资源清理，并且讲UFO都销毁

```c#
    public void GameOver(){
        c.running = false;
        trial = 0; time = 0;
        for (int i = 0; i < fa.Used_UFO.Count; i++) fa.Used_UFO.RemoveAt(i);
        for (int i = 0; i < fa.Unused_UFO.Count; i++) fa.Unused_UFO.RemoveAt(i);
    }
```

- `NextRound()`：用来控制游戏回合的进行，调用该函数可以跳转到下一个回合

```c#
	 public void NextRound(){
        trial = 0; time = 0; round ++;
    }
```

- `Awake()`：该函数在游戏运行前开始执行，该函数设置了游戏的帧率，以及回合数，分数，时间等信息，并且得到了控制器的实例，以及运用了 `InvokeRepeating()` 函数来实现重复执行的两个函数，作用分别是更新游戏的时间，以及更新游戏的trial

```c#
    void Awake(){
        c = Controller.getInstance();
        c.setFPS(60); c.currentModel = this; c.running = true;

        LoadResources();
        score = 0; round = 1; trial = 0; time = 0;
        fa = Singleton.Instance;

        // 重复执行
        InvokeRepeating("UpdateTime", 1f, 1f);
        InvokeRepeating("NewTrial", 1f, 3f);
    }
```

- `Start()`：游戏开始时进行加载游戏的资源，创建飞碟

```c#
    public void Start(){
        for (int i = 0; i < 10; i++) fa.CreateUFO();
    }
```

- `Restart()`：对应与游戏界面中的 `restart` 按钮，用于重启游戏，将所有的数据进行初始化，由于应用的是工厂模式来管理飞碟，所以飞碟并不会被销毁，而是在 `Used_UFO` 和 `Unused_UFO` 中进行互相的转换，从而节省了游戏资源

```c#
    public void Restart(){
        c.running = false;
        score = 0; round = 1; trial = 0; time = 0;

        List<GameObject> l_ufo = fa.Used_UFO;
        List<GameObject> list = new List<GameObject>();

        foreach (GameObject ufo in l_ufo) list.Add(ufo);
        l_ufo.Clear();
        
        foreach (GameObject obj in list) fa.RecycleUFO(obj);
        for (int i = 0; i < 10; i++) fa.CreateUFO();
        
        c.running = true;
    }
```

- `NewTrial()`：在 `InvokeRepeating()` 中调用，作用是每三秒换一个新的trial

```c#
// 每三秒换一个新的trial
public void NewTrial(){
    if (c.running == false) return;

    trial += 1;
    while (fa.Used_UFO.Count < 10){
        fa.CreateUFO();
    }
}
```
-  `Changemode()`：更换游戏模式

```c#
 public void Changemode(){ fa.mode = 1 - fa.mode; }
```

- `UpdateTime()`：在 `InvokeRepeating()` 中调用，作用是用来更新时间，并且每30秒更新一次round

```c#
    // 时间的更新，每30秒更换round
    public void UpdateTime(){
        if(c.running == false) return;

        time += 1;
        if (time >= 30){
            time = 0;
            trial = 0;
            round += 1;
        }
    }
```

- `Update()`：每帧调用一次，首先控制飞碟的运动，使得不同回合的飞碟运行的速度不同，并且对于超出游戏界面的飞碟进行回收；还实现了数表的点击功能，该实现是参考了老师课件中给出的代码参考，并且在点击的过程中打印点击的不同的UFO共有多少个

```c#
    void Update(){
        if (c.running == false) return;
        List<GameObject> l_ufo = fa.Used_UFO;
        try {
            foreach (GameObject ufo in l_ufo){
                Vector3 v = new Vector3(ufo.transform.localRotation.x, ufo.transform.localRotation.y, ufo.transform.localRotation.z);
                ufo.transform.Translate(v * Time.deltaTime * round * 2); // 控制每回合不同的速度

                // 超出边界则需要回收
                if (ufo.transform.position.x > 10 || ufo.transform.position.x < -10) fa.RecycleUFO(ufo);
                if (ufo.transform.position.y > 10 || ufo.transform.position.y < -10) fa.RecycleUFO(ufo);
                if (ufo.transform.position.z < -10) fa.RecycleUFO(ufo);
                
            }
        }
        catch {}

        // 实现鼠标的点击功能
        if (Input.GetButtonDown("Fire1")) {
			Vector3 mp = Input.mousePosition; //get Screen Position

			//create ray, origin is camera, and direction to mousepoint
			Camera ca;
			ca = Camera.main;

			Ray ray = ca.ScreenPointToRay(Input.mousePosition);

			//Return the ray's hits
			RaycastHit[] hits = Physics.RaycastAll (ray);

			foreach (RaycastHit hit in hits) {
                if (hit.transform.gameObject == null) continue;
                
                if (hit.transform.gameObject.name == "UFO1(Clone)") score += 1;
                if (hit.transform.gameObject.name == "UFO2(Clone)") score += 2;
                if (hit.transform.gameObject.name == "UFO3(Clone)") score += 3;
                // 统计 hit 到的不同的 UFO 有多少个
				print ("Hit " + hit.transform.gameObject.name);

                fa.RecycleUFO(hit.transform.gameObject);
			}
		}	
```

​		`Console` 中打印的信息如下所示：

<img src="https://img-blog.csdnimg.cn/2020101319110245.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

#### View.cs

该文件实现了整个游戏界面的设置

- 类中的成员变量：`action`变量用来获得游戏的模型实例，`fon1`设置游戏的字体等信息，`font2`设置游戏中字体等相关信息，`digit`设置游戏中数字的相关信息

```c#
    private Model action;
    private GUIStyle font1 = new GUIStyle(); // 设置文字
    private GUIStyle font2 = new GUIStyle(); // 设置文字
		private GUIStyle font3 = new GUIStyle(); // 设置文字
    private GUIStyle digit = new GUIStyle(); // 设置数字
```

- `Start()`：游戏开始时调用该函数，该函数实现了获取 `Model` 实例，并且设置了相关字体和数字的大小和显示的颜色信息

```c#
    void Start(){
        action = Controller.getInstance().currentModel as Model;

        font1.fontSize = 20; font1.normal.textColor = Color.blue;
        digit.fontSize = 20; digit.normal.textColor = Color.red;
        font2.fontSize = 60;
      	font3.fontSize = 60; font3.normal.textColor = Color.red;
    }
```

- `OnGUI()`：首先判断游戏如果超过5轮则需要显示 `Game Over！`，并且调用 `GameOver()` 函数来销毁游戏资源，如果在游戏规定的回合数内，则用于显示 `Round`, `Score`, `Trial`, `Time` 等相关标签的信息, 以及 `Pause`, `Restart`, `NextRound` , `Change Mode` 四个按钮的信息

```c#
    public void OnGUI(){
        // 游戏只进行5轮(round)
        if (action.round >= 6){
            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 50, 200, 200), "Game Over！", font2);
          	GUI.Label(new Rect(Screen.width / 2 - 180, Screen.height / 2 - 50, 200, 200), "You Get Score: " + action.score, font3);
            action.GameOver();
        }else {
            GUI.Label(new Rect(10, 10, 200, 200),"Round: ", font1);
            GUI.Label(new Rect(75, 10, 200, 200),"" + action.round, digit);

            GUI.Label(new Rect(10, 40, 200, 200),"Score: ", font1); 
            GUI.Label(new Rect(72, 40, 200, 200),"" + action.score, digit);

            GUI.Label(new Rect(10, 70, 200, 200),"Trial: ", font1);
            GUI.Label(new Rect(55, 70, 200, 200),"" + action.trial, digit);

            GUI.Label(new Rect(Screen.width - 80, 10, 200, 200),"Time: ", font1);
            GUI.Label(new Rect(Screen.width - 30, 10, 200, 200),"" + action.time, digit);

          // 下一个回合
            if (GUI.Button(new Rect(10, Screen.height - 230, 100, 50), "Next Round")) action.NextRound();
          
            // 暂停
            if (GUI.Button(new Rect(10, Screen.height - 150, 100, 50), "Pause")) action.Pause();
            
            // 重新开始
            if (GUI.Button(new Rect(10, Screen.height - 80, 100, 50), "Restart")) action.Restart();
          
          	// 更换模式
            if (GUI.Button(new Rect(10, Screen.height - 290, 100, 50), "Change Mode")) action.Changemode();
        } 
    }
```

#### SSAction

动作实现

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSAction : ScriptableObject {

    public bool enable = true;
    public bool destory = false;

    public GameObject gameobject{ get; set;}
    public Transform transform{ get; set; }
    public ISSActionCallback callback{ get; set; }

    public virtual void Start () {
        throw new System.NotImplementedException();
    }

    public virtual void Update () {
        throw new System.NotImplementedException ();
    }
}
```

#### SSActionManager

动作管理者

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSActionManager : MonoBehaviour {  

    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction> ();
    private List<SSAction> waitingAdd = new List<SSAction>();
    private List<int> waitingDelete = new List<int>();
    protected void Update() {
        foreach (SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
        
        waitingAdd.Clear();
        foreach (KeyValuePair<int, SSAction> kv in actions) {
            SSAction ac = kv.Value;
            if (ac.destory) {
                waitingDelete.Add(ac.GetInstanceID());
            } else if (ac.enable) {
                ac.Update();
            }
        }
        foreach(int key in waitingDelete) {
            SSAction ac = actions[key]; 
            actions.Remove(key);
            Destroy(ac);
        }
        waitingDelete.Clear();
    }

    public void RunAction(GameObject gameobject, SSAction action, ISSActionCallback manager) {
        action.gameobject = gameobject;
        action.transform = gameobject.transform;
        action.callback = manager;
        waitingAdd.Add(action);
        action.Start();
    }
}
```

#### ISSActionCallback

动作回调

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SSActionEventType:int {Started, Completed}

public interface ISSActionCallback {
    void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Completed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null);
}
```

#### Adapter

适配器模式的根文件

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 适配器模式
public class Adapter : SSActionManager, ISSActionCallback{
   
    public bool running;

    public virtual void fly(GameObject ufo,float speed){}

    public void SSActionEvent(SSAction source,SSActionEventType events = SSActionEventType.Completed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null) {
        
    }

    public void pause(){ running = !running; }

    void Start(){ running = true; }

    void Update(){
        if (running) base.Update(); // 调用基类的方法
    }
}
```

#### CCActionManager1

第一种运动模式的动作控制器

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 物理运动
public class CCActionManager1 : Adapter{
    public override void fly(GameObject ufo, float speed){
        CCFlyAction1 action = CCFlyAction1.GetSSAction(speed);
        this.RunAction(ufo, action, this);
    }
}

```

#### CCActionManager2

第二种运动模式的动作控制器

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 运动学
public class CCActionManager2 : Adapter{
    public override void fly(GameObject ufo, float speed){
        CCFlyAction2 action = CCFlyAction2.GetSSAction(speed);
        this.RunAction(ufo, action, this);
    }
}

```

#### CCFlyAction1

第一种运动模式的飞行动作，以恒定的速度进行飞行

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction1 : SSAction{

    public float speed;

    public static CCFlyAction1 GetSSAction(float speed){
        CCFlyAction1 action = ScriptableObject.CreateInstance<CCFlyAction1>();
        action.speed = speed;
        return action;
    }

    public override void Update(){
        Vector3 v = new Vector3(this.gameobject.transform.localRotation.x, this.gameobject.transform.localRotation.y, this.gameobject.transform.localRotation.z);
        this.transform.position = Vector3.MoveTowards (this.transform.position, this.transform.position + v * 100000, speed * Time.deltaTime);

        if(this.gameobject.transform.position.x > 10 || this.gameobject.transform.position.x < -10){
            this.destory=true;
            this.callback.SSActionEvent (this);
        }
        if(this.gameobject.transform.position.y > 10 || this.gameobject.transform.position.y < -10){
            this.destory=true;
            this.callback.SSActionEvent (this);
        }
        if(this.gameobject.transform.position.z < -10){
            this.destory=true;
            this.callback.SSActionEvent (this);
        }
    }
}

```

#### CCFlyAction2

第二种运动模式的飞行动作，给物体增加额外的动力进行运动

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction2 : SSAction{

    public float speed;

    public static CCFlyAction2 GetSSAction(float speed){
        CCFlyAction2 action = ScriptableObject.CreateInstance<CCFlyAction2>();
        action.speed = speed;
        return action;
    }

    // Update is called once per frame
    public override void Update(){
        Vector3 v = new Vector3(this.gameobject.transform.localRotation.x, this.gameobject.transform.localRotation.y, this.gameobject.transform.localRotation.z);
        this.gameobject.GetComponent<Rigidbody>().AddForce(v * 10f * speed);
        
        if(this.gameobject.transform.position.x > 10 || this.gameobject.transform.position.x < -10){
            this.destory=true;
            this.callback.SSActionEvent (this);
        }
        if(this.gameobject.transform.position.y > 10 || this.gameobject.transform.position.y < -10){
            this.destory=true;
            this.callback.SSActionEvent (this);
        }
        if(this.gameobject.transform.position.z < -10){
            this.destory=true;
            this.callback.SSActionEvent (this);
        }
    }
}

```

## 打靶游戏（可选作业）

- 游戏内容要求：
  1. 靶对象为 5 环，按环计分；
  2. 箭对象，射中后要插在靶上
     - **增强要求**：射中后，箭对象产生颤抖效果，到下一次射击 或 1秒以后
  3. 游戏仅一轮，无限 trials；
     - **增强要求**：添加一个风向和强度标志，提高难度

## 打靶游戏制作

### 游戏说明

游戏界面有一个由五个圆环构成的靶子，玩家通过鼠标点击靶子，即可射出飞镖，飞镖击中靶子不同的位置可以得到不同的分数，分数在左上角可以看到，游戏运行的时间也可以在左上角进行查看。

### 游戏截图和视频

<img src="https://img-blog.csdnimg.cn/2020110300424811.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />![在这里插入图片描述](https://img-blog.csdnimg.cn/20201103004307233.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

<img src="https://img-blog.csdnimg.cn/2020110300424811.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />![在这里插入图片描述](https://img-blog.csdnimg.cn/20201103004307233.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

游戏运行视频地址：[传送门](https://www.bilibili.com/video/BV1gK411P7NC)

### 博客地址

[传送门]()

### 游戏 Assets 结构

项目的 `Assets` 结构如下图所示：

<img src="https://img-blog.csdnimg.cn/20201103004521795.png#pic_center" alt="在这里插入图片描述" style="zoom:50%;" />

- `Resources/Materials`：存储了不同圆环的颜色

<img src="https://img-blog.csdnimg.cn/20201103004833888.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom: 33%;" />

- `Resources/Prefabs`：存储了不同圆环的对象以及飞镖的对象

<img src="https://img-blog.csdnimg.cn/20201103004848849.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- `Scenes`：存储了游戏中的场景，直接打开即可正常运行游戏

<img src="https://img-blog.csdnimg.cn/2020110300490629.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- `Scripts`：游戏项目中的代码

<img src="https://img-blog.csdnimg.cn/20201103004921117.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

### 代码实现

#### Model

进行了飞镖的初始化，并且实现了时间计时的功能

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    private GameObject obj;

    public static int time;

    void UpdateTime(){ time ++; }

    // 时间的每秒递增
    void Awake() {
        InvokeRepeating("UpdateTime", 1f, 1f);
    }

    void Start(){
        // 初始化飞镖
        obj = Resources.Load<GameObject>("Prefab/Dart");
        time = 0;
    }

    void Update(){
        // 实现飞镖的发射
        if (Input.GetMouseButtonDown(0)){
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit h; Vector3 v;
            if (Physics.Raycast(r, out h)){
                v = h.point;
                v.z = Camera.main.transform.position.z + 2;
                obj.transform.position = v;

                GameObject dart = GameObject.Instantiate(obj);
                dart.AddComponent<ModelController>();
                dart.AddComponent<Rigidbody>();
            }
        }
    }
}
```

#### ModelController

实现了飞镖的速度的设置，这里速度我设置成一个合适的值方便游戏，以及发生碰撞后飞镖的销毁。还设置了飞镖的飞行状态。

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour {
    private float speed;
    private bool fly;

    void Start(){
        fly = true;
        speed = 30.0f; // 速度快一点不容易脱靶
    }

    void Update(){
        if (this.gameObject.transform.position.y < -5) Destroy(this.gameObject);
        
        if (fly){
            Vector3 v = this.gameObject.transform.position;
            v.z -= -speed * Time.deltaTime;
            this.gameObject.transform.position = v;
        }
    }

    // 当发生碰撞时
    void OnCollisionEnter(Collision collision){
        fly = false;
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());
    }
}

```

#### Ring

主要实现了对圆环的初始化，以及各个组件的设置

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring {
    private GameObject ring1, ring2, ring3, ring4, ring5; // 设有五环

    public Ring(){
        ring1 = Resources.Load<GameObject>("Prefab/Ring1");
        ring1 = GameObject.Instantiate(ring1);

        ring2 = Resources.Load<GameObject>("Prefab/Ring2");
        ring2 = GameObject.Instantiate(ring2);

        ring3 = Resources.Load<GameObject>("Prefab/Ring3");
        ring3 = GameObject.Instantiate(ring3);

        ring4 = Resources.Load<GameObject>("Prefab/Ring4");
        ring4 = GameObject.Instantiate(ring4);

        ring5 = Resources.Load<GameObject>("Prefab/Ring5");
        ring5 = GameObject.Instantiate(ring5);

        // 使得圆环能在一起
        ring2.transform.parent = ring1.transform;
        ring3.transform.parent = ring1.transform;
        ring4.transform.parent = ring1.transform;
        ring5.transform.parent = ring1.transform;

        ring1.AddComponent<Score>();
        ring2.AddComponent<Score>();
        ring3.AddComponent<Score>();
        ring4.AddComponent<Score>();
        ring5.AddComponent<Score>();

        // 将圆环的名字设置为分数，这样方便记分
        ring1.name = "1";
        ring2.name = "2";
        ring3.name = "3";
        ring4.name = "4";
        ring5.name = "5";
    }
}

```

#### Score

实现了分数的设置，当飞镖碰撞到圆环时，分数增加

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    public int _score; // 每个圆环上的得分
    public static int score = 0; // 得分

    int max(int a, int b){
        if (a > b) return a;
        return b;
    }

    // 当发生碰撞时分数增加
    void OnCollisionEnter(Collision collision){
        // print(this.gameObject.name);
        _score = max(_score, int.Parse(this.gameObject.name));
        score += _score;
    }
}

```

#### View

实现了界面的展示，界面总共分为两个部分，一部分是分数的统计，另一部分是时间的统计

```c#
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {
    private GUIStyle font = new GUIStyle(); // 设置文字
    private GUIStyle digit = new GUIStyle(); // 设置数字
    private Ring r;
    private Model action;

    void Start(){
        font.fontSize = 20; font.normal.textColor = Color.blue;
        digit.fontSize = 20; digit.normal.textColor = Color.red;
        r = new Ring();
    }

    void OnGUI(){
        GUI.Label(new Rect(10, 10, 200, 200), "Score：", font);
        GUI.Label(new Rect(75, 10, 200, 200), " " + Score.score, digit);

        GUI.Label(new Rect(10, 40, 200, 200), "Time：", font);
        GUI.Label(new Rect(72, 40, 200, 200), "" + Model.time, digit);
    }
}

```

## 实验总结

通过本次实验，了解到了 Adapter 模式，并能够基于此模式进行游戏的设计，也学会了物理系统的碰撞的设置，刚体等概念。