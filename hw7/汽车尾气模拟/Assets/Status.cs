using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int status; // 0 : 启动；1 : 运行；2 : 损坏
    private GameObject begin, run, damage;

    void Start(){
        status = -1;
        begin = transform.Find("Particles/begin").gameObject;
        run = transform.Find("Particles/run").gameObject;
        damage = transform.Find("Particles/damage").gameObject;

        begin.SetActive(false);
        run.SetActive(false);
        damage.SetActive(false);
    }

    void Update(){
        if (status == 0){
            begin.SetActive(true);
            run.SetActive(false);
            damage.SetActive(false);
        }else if (status == 1){
            begin.SetActive(false);
            run.SetActive(true);
            damage.SetActive(false);
        }else if (status == 2){
            begin.SetActive(false);
            run.SetActive(false);
            damage.SetActive(true);
        }
    }
}
