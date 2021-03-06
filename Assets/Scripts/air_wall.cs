﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class air_wall : MonoBehaviour {

    public Transform zhu_jue;

    public GameObject wall_left;
    public GameObject wall_right;

    //public GameObject moon;


    private Vector3 zhu_jue_wz;//主角位置
    private Vector3 wall_left_wz; //墙位置
    private Vector3 wall_right_wz;
    //private Vector3 moon_wz;//月亮的位置


    private float wall_juli = 80;

    private bool wall_bool = true;
    private bool wall_bool_left = true;
    private bool wall_bool_right = true;

    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
        //取得主角的位置
        zhu_jue_wz = zhu_jue.transform.position;
        //Debug.Log(zhu_jue_wz);

        //月亮
        //moon_gensui();

        //取得墙位置
        wall_wz();

        xiao_hui();
        wall_yidong();
    }

    void wall_wz()//取得墙位置
    {
        if(wall_bool_left == true)
        {
            wall_left_wz = wall_left.transform.position;
            //Debug.Log(wall_left_wz);
        }
        
        if(wall_bool_right == true)
        {
            wall_right_wz = wall_right.transform.position;
            //Debug.Log(wall_right_wz);
        }
    }


    void xiao_hui()//销毁墙
    {   if(wall_bool == true)
        {
            if (zhu_jue_wz.x >= 50)
            {
                GameObject.Destroy(wall_right);
                wall_bool = false;
                wall_bool_right = false;
            }
            if (zhu_jue_wz.x <= -50)
            {
                GameObject.Destroy(wall_left);
                wall_bool = false;
                wall_bool_left = false;
            }
        }
    }

    void wall_yidong()//控制墙跟随主角向前移动
    {
        if(wall_bool == false)
        {
            if (zhu_jue_wz.x - wall_left_wz.x >= wall_juli && wall_bool_right == false)
            {
                wall_left_wz.x = zhu_jue_wz.x - 80f;
                wall_left.transform.position = new Vector3(wall_left_wz.x, 0, 0);
            }
            if (zhu_jue_wz.x - wall_right_wz.x <= -wall_juli && wall_bool_left == false)
            {
                wall_right_wz.x = zhu_jue_wz.x + 80f;
                wall_right.transform.position = new Vector3(wall_right_wz.x, 0, 0);
            }
        }  
    }

    //void moon_gensui() //月亮跟随
    //{
    //    moon_wz = new Vector3(zhu_jue_wz.x - 10f, 8, 0);
    //    moon.transform.position = moon_wz;

    //}
   
}
