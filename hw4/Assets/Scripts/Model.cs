using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 模型
public class Model : MonoBehaviour, Interface_Model, IUserAction{
    public int round;
    public int score;
    public int trial;
    public int time;
    Controller c;

    public Factory fa;

    // 接口实现
    public void LoadResources(){}
    public void Pause(){ c.running = !c.running; }
    public void GameOver(){
        c.running = false;
        trial = 0; time = 0;
        for (int i = 0; i < fa.Used_UFO.Count; i++) fa.Used_UFO.RemoveAt(i);
        for (int i = 0; i < fa.Unused_UFO.Count; i++) fa.Unused_UFO.RemoveAt(i);
    }
    public void NextRound(){
        trial = 0; time = 0; round ++;
    }

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

    public void Start(){
        for (int i = 0; i < 10; i++) fa.CreateUFO();
    }

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

    // 每三秒换一个新的trial
    public void NewTrial(){
        if (c.running == false) return;

        trial += 1;
        while (fa.Used_UFO.Count < 10){
            fa.CreateUFO();
        }
    }

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

    }
}
