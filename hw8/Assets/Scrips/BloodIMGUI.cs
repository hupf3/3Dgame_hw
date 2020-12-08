using UnityEngine;
public class BloodIMGUI : MonoBehaviour
{
    private Rect pos; // 血条显示的位置
    private Texture2D green, yellow, red; // 血条渐变的背景颜色
    private float preBlood; // 之前的血量
    private int isChange; // 判断是否按了按钮
    // 增加或减少的按钮
    private Rect btn1;
    private Rect btn2;
    public float curBlood; // 当前的血量
    
    void Start()
    {
        // 将颜色赋值
        yellow = Resources.Load<Texture2D>("color/yellow");
        green = Resources.Load<Texture2D>("color/green");
        red = Resources.Load<Texture2D>("color/red");
        // 设置位置
        pos = new Rect(Screen.width/2 - 100, 50, 200, 25);
        curBlood = preBlood = 90;
        // 设置按钮位置
        btn1 = new Rect(Screen.width / 2 - 100, 15, 30, 30);
        btn2 = new Rect(Screen.width / 2 + 70, 15, 30, 30);

        isChange = 0;
    }

    void OnGUI()
    {
        // 控制血条的按钮
        if (GUI.Button(btn1, " + ")) isChange = 1;
        if (GUI.Button(btn2, " - ")) isChange = 2;

        if (isChange == 1){
            curBlood = curBlood + 10 > 100 ? 100 : curBlood + 10;
            isChange = 0;
        }
        else if (isChange == 2){
            curBlood = curBlood - 10 < 0 ? 0 : curBlood - 10;
            isChange = 0;
        }

        GUIStyle style = new GUIStyle();
        GUI.Button(pos, "");
        // 不同数值设置不同的血量
        if (curBlood >= 80) style.normal.background = green;
        else if (curBlood <= 20) style.normal.background = red;
        else style.normal.background = yellow;
        
        // 使得血量变化更加流畅
        preBlood = Mathf.Lerp(preBlood, curBlood, 0.1f);
        GUI.Button(new Rect(pos.position.x, pos.position.y, preBlood / 100 * pos.size.x, pos.size.y), "", style);
    }
}