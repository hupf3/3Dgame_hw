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
