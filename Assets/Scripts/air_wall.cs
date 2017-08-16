using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class air_wall : MonoBehaviour {

    public Transform zhu_jue;

    public Transform wall_left;
    public Transform wall_right;

    private Vector3 zhu_jue_wz;//主角位置
    private Vector3 wall_left_wz; //墙位置
    private Vector3 wall_right_wz;

    private float wall_juli = 80;

    private bool wall_bool = true;

    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
        //取得主角的位置
        zhu_jue_wz = zhu_jue.transform.position;
        //取得墙位置
        wall_left_wz = wall_left.transform.position;
        wall_right_wz = wall_right.transform.position;

        sheng_cheng();
        wall_yidong();
    }

    void sheng_cheng()//第一次生成墙壁，如果玩家选择往某一方向移动，那么会在反方向生成一个空气墙
    {   if(wall_bool == true)
        {
            if (zhu_jue_wz.x >= 50)
            {
                GameObject.Instantiate(wall_left, new Vector3(-wall_juli + zhu_jue_wz.x,0,0),Quaternion.identity);
                wall_bool = false;
            }
            if (zhu_jue_wz.x <= -50)
            {
                GameObject.Instantiate(wall_right, new Vector3(wall_juli + zhu_jue_wz.x, 0, 0), Quaternion.identity);
                wall_bool = false;
            }
            
        }
    }

    void wall_yidong()//控制墙跟随主角向前移动
    {
        if(wall_bool == false)
        {
            if (zhu_jue_wz.x - wall_left_wz.x >= wall_juli)
            {
                wall_left_wz.x = zhu_jue_wz.x - 80f;
            }
            if (zhu_jue_wz.x - wall_right_wz.x <= wall_juli)
            {
                wall_right_wz.x = zhu_jue_wz.x + 80f;
            }
        }  
    }
   
}
