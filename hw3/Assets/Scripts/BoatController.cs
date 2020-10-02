using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 船的控制器
public class BoatController {
    readonly GameObject boat;
    // readonly Moving mov;
    readonly Vector3 sPosition = new Vector3 (5, 1, 0); // 起始位置
    readonly Vector3[] sPositions;
    readonly Vector3 ePosition = new Vector3 (-5, 1, 0); // 到达位置
    readonly Vector3[] ePositions;

    int st_pos; // 起始点还是终点：-1:终点 1:起点
    RoleController[] member = new RoleController[2];

    public float speed = 15;
    
    public BoatController() {
        st_pos = 1;

        sPositions = new Vector3[] { new Vector3 (4.5F, 1.5F, 0), new Vector3 (5.5F, 1.5F, 0) };
        ePositions = new Vector3[] { new Vector3 (-5.5F, 1.5F, 0), new Vector3 (-4.5F, 1.5F, 0) };

        boat = Object.Instantiate (Resources.Load ("Perfabs/Boat", typeof(GameObject)), sPosition, Quaternion.identity, null) as GameObject;
        boat.name = "boat";

        // mov = boat.AddComponent (typeof(Moving)) as Moving;
        boat.AddComponent (typeof(ClickGUI));
    }


    // public void Move() {
    //     if (st_pos == -1) {
    //         mov.setDestination(sPosition);
    //         st_pos = 1;
    //     } else {
    //         mov.setDestination(ePosition);
    //         st_pos = -1;
    //     }
    // }

    public Vector3 getDest() {
        if (st_pos == -1) return sPosition;
        else return ePosition;
    }

    public void move() {
        if (st_pos == -1) st_pos = 1;
            else st_pos = -1;
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
        // mov.reset ();
        if (st_pos == -1) move ();
        boat.transform.position = sPosition;
        member = new RoleController[2];
    }
}
