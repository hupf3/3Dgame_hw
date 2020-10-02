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

	private FirstActionController firstAC;

	void Awake() {
		Director d = Director.getInstance ();
		d.currentSceneController = this;
		uGUI = gameObject.AddComponent <UserGUI>() as UserGUI;
		roles = new RoleController[6];
		LoadResources();
		time = 60;
	}

	void Start() {
		firstAC = GetComponent<FirstActionController>();
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
		// boat.Move ();
		firstAC.moveBoat(boat);
		boat.move();
		uGUI.isWin = isfinished ();
	}

	public void MoveRole(RoleController r) {
		if (r.isOnBoat ()) {
			GroundController which_g;
			if (boat.get_st_pos () == -1) which_g = g2;
			else which_g = g1;
			
			boat.GetOffBoat (r.getName());
			// r.Movingto (which_g.getEmptyPosition ());
			firstAC.moveCharacter(r, which_g.getEmptyPosition ());
			r.getGround (which_g);
			which_g.getGround (r);
		} else {									
			GroundController which_g = r.getGroundController ();

			if (boat.getEmptyIndex () == -1) return; // 船是空的		
			if (which_g.get_st_pos () != boat.get_st_pos ()) return;

			which_g.getOffGround(r.getName());
			// r.Movingto (boat.getEmptyPosition());
			firstAC.moveCharacter(r, boat.getEmptyPosition());
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
