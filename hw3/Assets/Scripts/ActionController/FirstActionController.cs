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
