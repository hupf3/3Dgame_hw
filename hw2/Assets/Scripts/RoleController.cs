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