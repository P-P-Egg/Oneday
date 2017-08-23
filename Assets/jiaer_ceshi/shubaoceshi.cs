﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shubaoceshi : MonoBehaviour
{
    private Vector3 begin = new Vector3();
    private Vector3 end = new Vector3();
    public float begintime = new float();
    public float endtime = new float();
    public float force = 1;
    public Vector3 force1 = new Vector3();

    public Vector3 xiang_liang = new Vector3();
    public Vector3 xiang_liang2;//转化后的向量
    public float grivate;

    public float vector3_ju_li;
    public float speed;
    public bool ce_shi = true;

    private float time1 = 0;//取消重力的计时器

    void Start()
    {
        grivate = GetComponent<Rigidbody2D>().gravityScale;
    }
    void Update()//如果用FixedUpdate会导致偶尔操作不触发
    {
        lidu();
    }


    private void FixedUpdate()
    {
        //lidu();

    }
    void lidu()
    {
        if (Input.GetMouseButtonDown(0))
        {
            begintime = Time.time;
            begin = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endtime = Time.time;

            end = Input.mousePosition;

            xiang_liang = end - begin;//取得向量

            xiang_liang2 = Vector3.Normalize(xiang_liang);//向量转化为单位向量

            vector3_ju_li = Vector3.Distance(end, begin);//取得两点距离

            speed = (vector3_ju_li / (endtime - begintime)) / 10;//取得速度
            if (speed <= 300)
            {
                speed = 300;
            }
            if (speed >= 520)
            {
                speed = 520;
            }




            /*GetComponent<Rigidbody2D>().gravityScale = 0;*///取消重力
        }



        if (Time.time < endtime + 0.2)
        {
            force1 = xiang_liang2 * speed * force;
            GetComponent<Rigidbody2D>().gravityScale = 0;//取消重力
            GetComponent<Rigidbody2D>().AddForce(force1/2);
            ce_shi = true;

        }

        if (Time.time >= endtime + 0.2 || Time.time <= endtime + 1)
        {

            GetComponent<Rigidbody2D>().gravityScale = 10;//重启重力
            ce_shi = false;
        }
    }

    
}
