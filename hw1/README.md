# 编程实践，小游戏
**[博客链接](https://blog.csdn.net/qq_43267773/article/details/108725590)**：包括了本次作业的简答题和附加题目

- **游戏内容： 井字棋 或 贷款计算器 或 简单计算器 等等**

- **技术限制： 仅允许使用 [IMGUI](https://docs.unity3d.com/Manual/GUIScriptingGuide.html) 构建 UI**

- **作业目的：**

  - **了解 OnGUI() 事件，提升 debug 能力**
  - **提升阅读 API 文档能力**

  我学习并制作了井字棋这个项目，实验的过程截屏如下所示：

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200922102757169.gif#pic_center)

- **游戏过程**：分为两个玩家进行游戏，第一个玩家是'X'，第二个玩家是'O'，如果某个玩家的棋子3个连成一条线那么就会显示该玩家获胜，如果最终棋盘填满也没有玩家获胜，则会显示“Play even(平局)”。在游戏进行途中，或者游戏结束后都可以进行重置，只需点击左边的reset按钮即可，棋盘会重新清零，开始新的游戏

- **游戏框架**：该游戏主要由9个按钮组成的棋盘，一个插入的背景图片，按钮组成的重置键，标签组成的游戏名称，以及最后游戏结束显示的结束语组成

- **代码说明**：首先设置两个全局变量，int类型的board数组代表 3 * 3 的棋盘，如果数值为0代表该位置为空，如果数值为1代表玩家1在此下了棋，若为2代表玩家2在此下了棋，和int类型step变量，用于记录当前的棋盘有多少位置被下过了

  ![在这里插入图片描述](https://img-blog.csdnimg.cn/20200922003729450.png#pic_center)

  然后是start()函数，包括了init()函数用来初始化棋盘，也就是清零board数组，并且将step设置为0

  ![在这里插入图片描述](https://img-blog.csdnimg.cn/20200922003910968.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

  接下来是isWin()，函数用来判断是否有人获胜，并且返回获胜的人，如果没有人获胜则返回0

  ![在这里插入图片描述](https://img-blog.csdnimg.cn/20200922004027510.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

  接下来就是OnGUI()函数，用来调用上面的初始化或者判断是否有人获胜，并且进行每一步下棋的操作，并且显示游戏的名称和背景，具体代码如下所示：

  ![在这里插入图片描述](https://img-blog.csdnimg.cn/20200922101923866.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

  ![在这里插入图片描述](https://img-blog.csdnimg.cn/20200922101951813.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FxXzQzMjY3Nzcz,size_16,color_FFFFFF,t_70#pic_center)

- **游戏运行**：创建一个空的游戏对象，将c#代码拖入进对象中，然后将图片拖入进img中即可成功运行井字棋
- **实验总结**：通过本次实验学会了OnGUI函数的完成，并且学会了按钮，标签的定义过程，也更加熟悉了在游戏运行时，各个函数的运行顺序和运行次数。也发现了unity做游戏的方便之处。
