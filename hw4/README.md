# 与游戏世界的交互--Hit UFO游戏

## Hit UFO游戏作业要求

编写一个简单的鼠标打飞碟（Hit UFO）游戏

- 游戏内容要求：
  1. 游戏有 n 个 round，每个 round 都包括10 次 trial；
  2. 每个 trial 的飞碟的色彩、大小、发射位置、速度、角度、同时出现的个数都可能不同。它们由该 round 的 ruler 控制；
  3. 每个 trial 的飞碟有随机性，总体难度随 round 上升；
  4. 鼠标点中得分，得分规则按色彩、大小、速度不同计算，规则可自由设定。
- 游戏的要求：
  - 使用带缓存的工厂模式管理不同飞碟的生产与回收，该工厂必须是场景单实例的！具体实现见参考资源 Singleton 模板类
  - 近可能使用前面 MVC 结构实现人机交互与游戏模型分离

如果你的使用工厂有疑问，参考：[弹药和敌人：减少，重用和再利用](http://www.manew.com/thread-48481-1-1.html)；参考：[Unity对象池（Object Pooling）理解与简单应用](https://gameinstitute.qq.com/community/detail/121124) 代码质量较低，比较凌乱

## Hit UFO游戏制作

### 游戏说明

#### 游戏玩法

玩家通过鼠标点击界面中随机出现的飞碟来获取积分，游戏界面会有两个按钮，一个是 `pause` 按钮，可以暂停游戏，另一个是 `restart` 按钮可以重新开始游戏

#### 规则说明

游戏中会有三种不同的飞碟，分别是红色，蓝色，绿色的飞碟，不同的飞碟大小会有不同，因此点击到不同的飞碟得分也会不同，红色飞碟最小，分数为3；蓝色飞碟大小适中，分数为2；绿色飞碟最大，分数为1.

游戏会分为5个回合(round)，每个回合中会有10次 trial ，每次 trial 出现的飞碟的数量，个数，种类，角速度，速度都是不同的，且每次 trial 仅持续 3 秒，意味着每回合的时间为30秒，30秒过后就是全新的回合。随着回合数的增加飞碟运行的速度会有提高，游戏的整体难度会变高。当第五回合游戏结束后，会显示 `Game Over` 游戏结束。

### 游戏截图和视频

游戏运行时的部分截图如下所示：

<img src="https://img-blog.csdnimg.cn/20201013192005636.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />


![在这里插入图片描述](https://img-blog.csdnimg.cn/20201013192030222.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)


<img src="https://img-blog.csdnimg.cn/20201013192633655.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

游戏的运行视频：[传送门](https://www.bilibili.com/video/BV1ZD4y1R74s)

### 博客地址

[传送门]()

### 游戏运行说明

将 `Assets` 文件夹下载到本地，然后直接通过unity打开该文件即可成功运行，或者新建个项目，用该 `Assets` 文件夹覆盖原有的，打开后即可正常运行

### 游戏Assets结构

项目的 `Assets` 结构如下图所示：

<img src="https://img-blog.csdnimg.cn/20201013172848931.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

- `Materials`：存储了不同的UFO所用的不同的颜色

<img src="https://img-blog.csdnimg.cn/20201013173034303.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

- `Resources/Prefabs`：存储了事先做好的UFO游戏对象，并且存为预制

<img src="https://img-blog.csdnimg.cn/20201013173336503.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

- `Scenes`：存储了游戏中的场景，直接打开该场景即可正常运行游戏

<img src="https://img-blog.csdnimg.cn/20201013173444349.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

- `Scripts`：游戏项目中的代码，本次项目实现是基于MVC架构的，并且使用了工厂模式进行管理

<img src="https://img-blog.csdnimg.cn/20201013173843477.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

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

- 类中的成员变量：`Used_UFO` 和 `Unused_UFO` 变量为两个 `List` 变量，分别存储了屏幕中存在的UFO即使用中的UFO，以及超出摄像机拍摄外即屏幕外的UFO也就是未使用的UFO

```C#
public List<GameObject> Used_UFO = new List<GameObject>();
public List<GameObject> Unused_UFO = new List<GameObject>();
```

- `CreateUFO()`： 函数实现了创建UFO，由于是用的工厂模式，所以创建的时候需要判断在未使用的UFO的 `List` 是否为空，如果为空则正常选择随机创建一个UFO；如果非空，则需要选择 `Unused_UFO` 中的UFO变为 `Used_UFO` 中的UFO，新UFO的位置以及角速度也是随机生成的

```c#
// 创建UFO
    public void CreateUFO(){
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

- `OnGUI()`：首先判断游戏如果超过5轮则需要显示 `Game Over！`，并且调用 `GameOver()` 函数来销毁游戏资源，如果在游戏规定的回合数内，则用于显示 `Round`, `Score`, `Trial`, `Time` 等相关标签的信息, 以及 `Pause`, `Restart`, `NextRound` 三个按钮的信息

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
        } 
    }
```

## 选做内容

### 要求

编写一个简单的自定义 Component （**选做**）

- 用自定义组件定义几种飞碟，做成预制
  - 参考官方脚本手册 https://docs.unity3d.com/ScriptReference/Editor.html
  - 实现自定义组件，编辑并赋予飞碟一些属性

### 实现

首先创建一个游戏对象 `Sphere`，将 `Scale` 用以下数据填写，得到一个圆盘状的对象如下所示：

<img src="https://img-blog.csdnimg.cn/20201013193927495.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:25%;" />

然后在此基础上加上一个新的对象 `Sphere` 放到上面的圆盘中间即可构成一个飞碟状的游戏对象，如下所示：

<img src="https://img-blog.csdnimg.cn/20201013194040465.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom: 33%;" />

将此对象用之前做好的 `Material` 上色，并命名为 New UFO 放入到预制中

<img src="https://img-blog.csdnimg.cn/20201013194205379.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

<img src="https://img-blog.csdnimg.cn/20201013194240261.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

然后创建一个新的代码文件用来设计New UFO的相关属性，我设置了防御值和生命值，代码文件 `NewUFO.cs`如下：

```c#
public class NewUFO : MonoBehaviour
{
    public int defenseValue; // 防御值
    public int healthValue; // 生命值
}
```

将写好的文件挂载到New UFO对象上即可配置对象的相关属性：

<img src="https://img-blog.csdnimg.cn/20201013194720931.png#pic_center" alt="在这里插入图片描述" style="zoom:33%;" />

在游戏中也可以根据UFO的属性进行不同规则的开发，使得游戏更加有趣味性，相关组件我保存到了对应的文件夹中

## 实验总结

通过本次实验，复习了之前的MVC架构，并且学会了与游戏世界的交互，能够将鼠标点击的功能以及键盘输入的功能实现在游戏中，增加了游戏的可玩性。通过对游戏对象增加不同的组件，可以使得游戏对象有更多的属性，可以增加游戏的趣味性。