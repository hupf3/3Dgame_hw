## 编程实践

- **阅读以下游戏脚本**

> Priests and Devils
>
> Priests and Devils is a puzzle game in which you will help the Priests and Devils to cross the river within the time limit. There are 3 priests and 3 devils at one side of the river. They all want to get to the other side of this river, but there is only one boat and this boat can only carry two persons each time. And there must be one person steering the boat from one side to the other side. In the flash game, you can click on them to move them and click the go button to move the boat to the other direction. If the priests are out numbered by the devils on either side of the river, they get killed and the game is over. You can try it in many > ways. Keep all priests alive! Good luck!

**程序需要满足的要求：**

- **play the game ( http://www.flash-game.net/game/2535/priests-and-devils.html )**
- **列出游戏中提及的事物（Objects）**
- **用表格列出玩家动作表（规则表），注意，动作越少越好**
- **请将游戏中对象做成预制**
- **在场景控制器 `LoadResources` 方法中加载并初始化长方形、正方形、球及其色彩代表游戏中的对象。**
- **使用 C# 集合类型有效组织对象**
- **整个游戏仅主摄像机和一个 Empty 对象， 其他对象必须代码动态生成！！。 整个游戏不许出现 Find 游戏对象， SendMessage 这类突破程序结构的 通讯耦合 语句。 违背本条准则，不给分**
- **请使用课件架构图编程，不接受非 MVC 结构程序**
- **注意细节，例如：船未靠岸，牧师与魔鬼上下船运动中，均不能接受用户事件！**

### 游戏运行说明
直接下载hw2中的 `assets` 文件夹，放到本地的文件夹中，然后用 `unity hub` 打开此文件夹，就会自动生成 unity 工程，然后加载场景点击运行就可以成功运行游戏

如果上述方法不行的话，可以新建一个工程然后用hw2中的 `assets` 文件夹覆盖新工程的同名文件夹，然后打开场景进行运行

### 游戏规则

**牧师与魔鬼**：这是一款经典的游戏，游戏很简单，玩家需要操控船只、牧师和魔鬼，然后使得一个岸边的三个牧师和三个魔鬼都移动到另一个岸边。并且需要在游戏限定的时间60秒内进行操作。	

**注意**：

- 要想使船移动，船上必须有牧师或魔鬼
- 船上最多有两个人物
- 不管哪个岸上，只要魔鬼数大于牧师数游戏失败(数量包括船只停靠时船上的人物数量)

### 博客地址
[博客地址](https://blog.csdn.net/qq_43267773/article/details/108878241)
应做题和思考题都在博客中有详细实现

### 游戏截图和视频

由于游戏过程比较长，所以只截取部分过程图，具体游戏的过程在视频链接中

[视频链接](https://www.bilibili.com/video/BV1ya4y157Vf/)

![在这里插入图片描述](https://img-blog.csdnimg.cn/20201002110757570.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

![在这里插入图片描述](https://img-blog.csdnimg.cn/20201002110914187.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

![在这里插入图片描述](https://img-blog.csdnimg.cn/20201002110955169.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

### 游戏Assets结构

设计的结构完全是按照标准的结构构建的，如下图所示

<img src="https://img-blog.csdnimg.cn/20200930002933307.png#pic_center" alt="在这里插入图片描述" style="zoom:50%;" />

- Materials：存放游戏中的Material
- Resources：存放游戏中的对象的预制
- Scenes：存放游戏的场景
- Scripts：存放游戏的c#代码
- Texture：存放关于物体的一些图片

### 游戏中的事物

<img src="https://img-blog.csdnimg.cn/2020092923135261.png#pic_center" alt="在这里插入图片描述" style="zoom:50%;" />

<img src="https://img-blog.csdnimg.cn/20200929231425190.png#pic_center" alt="在这里插入图片描述" style="zoom:50%;" />

- Water：水，也就是牧师与魔鬼需要渡过的，由长方体构成，并挂上网上找的图片
- Devil：魔鬼，由黑色的长方体构成
- Priest：牧师，由绿色的长方体构成
- ground：两个岸边，由长方体构成，并挂上图片
- Boat：木船，由长方体构成，并挂上图片

### MVC结构编程

在进行编程前，需要了解**MVC**的大体结构

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200927213329580.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

>MVC是界面人机交互程序设计的一种架构模式。它把程序分为三个部分：
>
>- 模型（Model）：数据对象及关系
>  - 游戏对象、空间关系
>- 控制器（Controller）：接受用户事件，控制模型的变化
>  - 一个场景一个主控制器
>  - 至少实现与玩家交互的接口（IPlayerAction）
>  - 实现或管理运动
>- 界面（View）：显示模型，将人机交互事件交给控制器处理
>  - 处收 Input 事件
>  - 渲染 GUI ，接收事件

本实验也是严格按照了MVC结构进行编写代码，代码的大致构成，如下图所示：

<img src="https://img-blog.csdnimg.cn/20200929231828741.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center" alt="在这里插入图片描述" style="zoom:50%;" />

> 类中的变量由于权限不同设置成了不同的类型，public，private，**readonly**(只读变量不可以对它的值进行修改)

接下来分别介绍各个代码实现的具体功能：

- **Director**：属于最高层的控制器，保持运行时始终有一个实例，这样方便了类与类之间的通信。

  主要的职责有：

  - 获取当前游戏的场景
  - 控制场景运行、切换、入栈与出栈
  - 暂停、恢复、退出
  - 管理游戏全局状态
  - 设定游戏的配置
  - 设定游戏全局视图

  可以通过一个抽象的场景接口访问不同场景的控制器

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 负责实例化
public class Director : System.Object {
	private static Director _instance;
	public SceneController currentSceneController { get; set; }

	public static Director getInstance() {
		if (_instance == null)  _instance = new Director ();
		return _instance;
	}
}
```

- **SceneController**：场景控制器：

  职责：

  - 管理本次场景所有的游戏对象
  - 协调游戏对象（预制件级别）之间的通讯
  - 响应外部输入事件
  - 管理本场次的规则（裁判）
  - 各种杂务

  可以看到它是由interface实现的，说明不能直接来创建对象，我们通过之前的学习可以知道，interface的使用需要一个类去继承它，这样才可以使用。

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 场景管理：加载所有的资源
public interface SceneController {
    void LoadResources ();
}
```

- **RoleController**：由类的名字就可以知道，这是对游戏人物的控制器，可以控制人物的移动，并且可以得到人物的相关信息，比如该游戏人物是牧师还是魔鬼，在船上还是在岸上，该游戏人物的名字是什么等等。不光需要以上的功能，由于人物是可以操控的所以我们还需要监控鼠标对人物的点击功能。

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 对游戏人物的控制器
public class RoleController {
    readonly GameObject obj;
    readonly Moving mov;
    readonly ClickGUI clickGUI;
    readonly int PorD; // 判断是牧师(0)还是魔鬼(1)

    bool _isOnBoat;
    GroundController gController;

    public RoleController(string r) {
        
        if (r == "priest") {
            obj = Object.Instantiate (Resources.Load ("Perfabs/Priest", typeof(GameObject)), Vector3.zero, Quaternion.identity, null) as GameObject;
            PorD = 0;
        } else {
            obj = Object.Instantiate (Resources.Load ("Perfabs/Devil", typeof(GameObject)), Vector3.zero, Quaternion.identity, null) as GameObject;
            PorD = 1;
        }
        mov = obj.AddComponent (typeof(Moving)) as Moving;

        clickGUI = obj.AddComponent (typeof(ClickGUI)) as ClickGUI;
        clickGUI.setController (this);
    }

    public void setName(string n) {
        obj.name = n;
    }

    public void setPosition(Vector3 p) {
        obj.transform.position = p;
    }

    public void Movingto(Vector3 dest) {
        mov.setDestination(dest);
    }

    public int getRole() {
        return PorD;
    }

    public string getName() {
        return obj.name;
    }

    public void getOnBoat(BoatController b) {
        gController = null;
        obj.transform.parent = b.getGameobj().transform;
        _isOnBoat = true;
    }

    public void getGround(GroundController coastCtrl) {
        gController = coastCtrl;
        obj.transform.parent = null;
        _isOnBoat = false;
    }

    public bool isOnBoat() {
        return _isOnBoat;
    }

    public GroundController getGroundController() {
        return gController;
    }

    public void reset() {
        mov.reset ();
        gController = (Director.getInstance ().currentSceneController as FirstController).g1;
        getGround (gController);
        setPosition (gController.getEmptyPosition ());
        gController.getGround (this);
    }
}
```

- **GroundController**：对地面的控制器，两个只读变量`sPosition、ePosition`记录了两个地面的位置， 然后`pos`数组记录了陆地上的可存放人物的位置；上陆地和下陆地的动作对变量的修改；有上陆地之前，需要判断陆地上的空位置的索引，然后才可以修改变量的内容

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 陆地的控制器
public class GroundController {
	readonly GameObject ground;
	readonly Vector3 sPosition = new Vector3(9, 1, 0);
	readonly Vector3 ePosition = new Vector3(-9, 1, 0);
	readonly Vector3[] pos;
	readonly int st_pos;

	RoleController[] roles;

	public GroundController(string ss) {
		pos = new Vector3[] {new Vector3(6.5F,2.25F,0), new Vector3(7.5F,2.25F,0), new Vector3(8.5F,2.25F,0), 
			new Vector3(9.5F,2.25F,0), new Vector3(10.5F,2.25F,0), new Vector3(11.5F,2.25F,0)};

		roles = new RoleController[6];

		if (ss == "from") {
			ground = Object.Instantiate (Resources.Load ("Perfabs/Ground", typeof(GameObject)), sPosition, Quaternion.identity, null) as GameObject;
			ground.name = "from";
			st_pos = 1;
		} else {
			ground = Object.Instantiate (Resources.Load ("Perfabs/Ground", typeof(GameObject)), ePosition, Quaternion.identity, null) as GameObject;
			ground.name = "to";
			st_pos = -1;
		}
	}

	public int getEmptyIndex() {
		for (int i = 0; i < roles.Length; i++) {
			if (roles [i] == null) return i;
		}
		return -1;
	}

	public Vector3 getEmptyPosition() {
		Vector3 p = pos [getEmptyIndex ()];
		p.x *= st_pos;
		return p;
	}

	public void getGround(RoleController r) {
		int ii = getEmptyIndex ();
		roles [ii] = r;
	}

	public RoleController getOffGround(string pname) {	// 0->priest, 1->devil
		for (int i = 0; i < roles.Length; i++) {
			if (roles [i] != null && roles [i].getName () == pname) {
				RoleController r = roles [i];
				roles [i] = null;
				return r;
			}
		}
		return null;
	}

	public int get_st_pos() {
		return st_pos;
	}

	public int[] getRoleNum() {
		int[] cnt = {0, 0};
		for (int i = 0; i < roles.Length; i++) {
			if (roles [i] == null) continue;

			if (roles [i].getRole () == 0) cnt[0]++;
			else cnt[1]++;
		}
		return cnt;
	}

	public void reset() {
		roles = new RoleController[6];
	}
}
```

- **BoatController**：对船的控制器，有两个只读变量`sPosition`,`ePosition`，来表示船的起始和终止位置，并且通过变量`st_pos`来判断是起点还是终点，还需要对船进行控制运动，所以需要监听鼠标的点击功能。还需要判断该船是否为空，还有空的位置所对应的索引，还需要得到上船下船等动作的通知；该类的实现和上面的陆地控制器的实现相似，所以设计起来也比较简单

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 船的控制器
public class BoatController {
    readonly GameObject boat;
    readonly Moving mov;
    readonly Vector3 sPosition = new Vector3 (5, 1, 0); // 起始位置
    readonly Vector3[] sPositions;
    readonly Vector3 ePosition = new Vector3 (-5, 1, 0); // 到达位置
    readonly Vector3[] ePositions;

    int st_pos; // 起始点还是终点：-1:终点 1:起点
    RoleController[] member = new RoleController[2];

    public BoatController() {
        st_pos = 1;

        sPositions = new Vector3[] { new Vector3 (4.5F, 1.5F, 0), new Vector3 (5.5F, 1.5F, 0) };
        ePositions = new Vector3[] { new Vector3 (-5.5F, 1.5F, 0), new Vector3 (-4.5F, 1.5F, 0) };

        boat = Object.Instantiate (Resources.Load ("Perfabs/Boat", typeof(GameObject)), sPosition, Quaternion.identity, null) as GameObject;
        boat.name = "boat";

        mov = boat.AddComponent (typeof(Moving)) as Moving;
        boat.AddComponent (typeof(ClickGUI));
    }


    public void Move() {
        if (st_pos == -1) {
            mov.setDestination(sPosition);
            st_pos = 1;
        } else {
            mov.setDestination(ePosition);
            st_pos = -1;
        }
    }

    public int getEmptyIndex() {
        for (int i = 0; i < member.Length; i++) {
            if (member [i] == null) return i;
        }
        return -1;
    }

    public bool isEmpty() {
        for (int i = 0; i < member.Length; i++) {
            if (member [i] != null) return false;
        }
        return true;
    }

    public Vector3 getEmptyPosition() {
        Vector3 p;
        int ii = getEmptyIndex ();
        if (st_pos == -1) p = ePositions[ii];
        else p = sPositions[ii];
        
        return p;
    }

    public void GetOnBoat(RoleController r) {
        int ii = getEmptyIndex ();
        member [ii] = r;
    }

    public RoleController GetOffBoat(string member_name) {
        for (int i = 0; i < member.Length; i++) {
            if (member [i] != null && member [i].getName () == member_name) {
                RoleController r = member [i];
                member [i] = null;
                return r;
            }
        }
        return null;
    }

    public GameObject getGameobj() {
        return boat;
    }

    public int get_st_pos() {
        return st_pos;
    }

    public int[] getRoleNum() {
        int[] cnt = {0, 0};
        for (int i = 0; i < member.Length; i++) {
            if (member [i] == null) continue;

            if (member [i].getRole () == 0) cnt[0]++;
            else cnt[1]++;
        }
        return cnt;
    }

    public void reset() {
        mov.reset ();
        if (st_pos == -1) Move ();
        
        member = new RoleController[2];
    }
}
```

- **Moving**：是一个关于对象运动的类，该类可以控制物体的移动速度`speed`，还可以设置物体的目的地，以达到物体可以移动。由于岸上的人物要想到达船上需要经过两个步骤，否则可能会穿模，也就是人物会穿过地表面，这样会不严谨，所以我设置了 `cur` 变量来判断当前物体运行的位置，然后再根据位置设置相应的目的地(`mid`, `dest`)，来解决此类问题。

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 关于对象运动的实现
public class Moving: MonoBehaviour {
		
    readonly float speed = 20;

    int cur; // 当前运行的位置
    Vector3 dest, mid; // 设置一个中间位置，使得运动不会穿模

    public void setDestination(Vector3 d) {
        dest = d; mid = d;

        if (d.y == transform.position.y) cur = 2;
        else if (d.y < transform.position.y) mid.y = transform.position.y;
        else mid.x = transform.position.x;
        
        cur = 1;
    }

    public void reset() {
        cur = 0;
    }

    void Update() {
        if (cur == 1) {
            transform.position = Vector3.MoveTowards (transform.position, mid, speed * Time.deltaTime);
            if (transform.position == mid) cur = 2;
        } else if (cur == 2) {
            transform.position = Vector3.MoveTowards (transform.position, dest, speed * Time.deltaTime);
            if (transform.position == dest) cur = 0;
        }
    }
}
```

- **FirstController**：高一层的控制器，控制着这个场景中的所有对象，包括其加载、通信、用户输入。

  继承了`SceneController` 和 `UserAction`，说明该控制器实现了对两个接口的继承并实现；该控制器还实现了加载游戏资源和加载游戏人物，并且有控制人物运动和船只的运动；游戏的运行时间的控制；判断游戏是否结束，和游戏结束的条件，如果结束了进行重置游戏，重新设置各个变量

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 总控制器
public class FirstController : MonoBehaviour, SceneController, UserAction {

	readonly Vector3 p_water = new Vector3(0,0.5F,0); // 水的位置
	
	UserGUI uGUI;

	public GroundController g1;
	public GroundController g2;
	public BoatController boat;
	private RoleController[] roles; 
	private float time; // 游戏运行的时间

	void Awake() {
		Director d = Director.getInstance ();
		d.currentSceneController = this;
		uGUI = gameObject.AddComponent <UserGUI>() as UserGUI;
		roles = new RoleController[6];
		LoadResources();
		time = 60;
	}

	// 游戏时间的运行
	void Update() {
		time -= Time.deltaTime;
		this.gameObject.GetComponent<UserGUI>().time = (int) time;
		uGUI.isWin = isfinished ();
	}

	private void loadRole() {
		for (int i = 0; i < 3; i++) {
			RoleController r = new RoleController ("priest");
			r.setName("priest" + i);
			r.setPosition (g1.getEmptyPosition ());
			r.getGround (g1); g1.getGround (r);

			roles [i] = r;
		}

		for (int i = 0; i < 3; i++) {
			RoleController r = new RoleController ("devil");
			r.setName("devil" + i);
			r.setPosition (g1.getEmptyPosition ());
			r.getGround (g1); g1.getGround (r);

			roles [i+3] = r;
		}
	}

	public void LoadResources() {
		GameObject water = Instantiate (Resources.Load ("Perfabs/Water", typeof(GameObject)), p_water, Quaternion.identity, null) as GameObject;
		water.name = "water";

		g1 = new GroundController ("from");
		g2 = new GroundController ("to");
		boat = new BoatController ();

		loadRole ();
	}

	public void MoveBoat() {
		if (boat.isEmpty ()) return;
		boat.Move ();
		uGUI.isWin = isfinished ();
	}

	public void MoveRole(RoleController r) {
		if (r.isOnBoat ()) {
			GroundController which_g;
			if (boat.get_st_pos () == -1) which_g = g2;
			else which_g = g1;
			
			boat.GetOffBoat (r.getName());
			r.Movingto (which_g.getEmptyPosition ());
			r.getGround (which_g);
			which_g.getGround (r);
		} else {									
			GroundController which_g = r.getGroundController ();

			if (boat.getEmptyIndex () == -1) return; // 船是空的		
			if (which_g.get_st_pos () != boat.get_st_pos ()) return;

			which_g.getOffGround(r.getName());
			r.Movingto (boat.getEmptyPosition());
			r.getOnBoat (boat);
			boat.GetOnBoat (r);
		}
		uGUI.isWin = isfinished ();
	}
// 判断是否结束 0:没有结束 1:输 2:赢
	int isfinished() {	
		if (time < 0) return 1;
		int p1 = 0; int d1 = 0; // 起始点牧师与魔鬼数量
		int p2 = 0; int d2 = 0; // 终点牧师与魔鬼数量

		int[] cnt1 = g1.getRoleNum (); // 起始点的人数
		p1 += cnt1[0]; d1 += cnt1[1];

		int[] cnt2 = g2.getRoleNum (); // 终点的人数
		p2 += cnt2[0]; d2 += cnt2[1];

		if (p2 + d2 == 6) return 2;

		int[] cnt3 = boat.getRoleNum (); // 船上人的数量
		if (boat.get_st_pos () == -1) {	
			p2 += cnt3[0]; d2 += cnt3[1];
		} else {	
			p1 += cnt3[0]; d1 += cnt3[1];
		}

		if (p1 < d1 && p1 > 0) return 1;
		if (p2 < d2 && p2 > 0) return 1;
		return 0;			
	}

	public void restart() {
		time = 60;
		boat.reset ();
		g1.reset (); g2.reset ();
		for (int i = 0; i < roles.Length; i++) roles [i].reset ();
	}
}
```

- **UserAction**：接口，定义了玩家可以进行的操作`MoveBoat()` 移动船只、`MoveRole` 移动人物、`restart`重新开始游戏。该接口通过别的类来继承，这样就可以实现得到用户的输入然后作出反应

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用户或玩家可以进行的操作
public interface UserAction {
    void MoveBoat();
    void MoveRole(RoleController r);
    void restart();
}
```

- **UserGUI**：用户交互，来设置整个用户界面，判断游戏是否胜利，如果胜利则显示`Win`，并有一个按钮表示是否需要重新玩这个游戏；如果失败则会显示`GameOver`，然后也可以进行游戏重置。在此我还设置了字体的大小和按钮的大小，方便观看，也不失美感

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UserGUI : MonoBehaviour {
	private UserAction u;
	public int isWin = 0;// 1:Gameover 2:Win
	public int time; // 游戏运行时间
	GUIStyle ssize, buttons, tsize;

	void Start() {
		u = Director.getInstance ().currentSceneController as UserAction;

		// 设置字体大小
		ssize = new GUIStyle(); tsize = new GUIStyle();
		ssize.fontSize = 45; tsize.fontSize = 20;
		ssize.alignment = TextAnchor.MiddleCenter;

		// 设置按钮大小
		buttons = new GUIStyle("button");
		buttons.fontSize = 30;

		// 设置游戏的时长
		time = 60;
	}
	// 判断是否胜利或失败，然后重置
	void OnGUI() {
		GUI.Label(new Rect(0, 0, 100, 50), "Time:  " + time, tsize);
		if (isWin == 1) {
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 80, 100, 50), "Gameover!", ssize);
			if (GUI.Button(new Rect(Screen.width / 2-65, Screen.height / 2, 140, 70), "Restart", buttons)) {
				isWin = 0; u.restart ();
			}
		} else if(isWin == 2) {
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 80, 100, 50), " Win!", ssize);
			if (GUI.Button(new Rect(Screen.width / 2 - 65, Screen.height / 2, 140, 70), "Restart", buttons)) {
				isWin = 0; u.restart ();
			}
		}
	}
}
```

- **ClickGUI**：用来监听鼠标的点击功能，并且调用`RoleController`实现对人物的控制

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 鼠标点击的控制
public class ClickGUI : MonoBehaviour {
	UserAction u;
	RoleController roleController;

	public void setController(RoleController rc) {
		roleController = rc;
	}

	void Start() {
		u = Director.getInstance ().currentSceneController as UserAction;
	}

	void OnMouseDown() {
		if (gameObject.name == "boat") u.MoveBoat ();
		else u.MoveRole (roleController);
	}
}
```

