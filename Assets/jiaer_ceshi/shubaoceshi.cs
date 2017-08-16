using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shubaoceshi : MonoBehaviour
{
    private Vector3 begin = new Vector3();
    private Vector3 end = new Vector3();
    private float begintime = new float();
    private float endtime = new float();
    public float force = 1;
    public Vector3 force1 = new Vector3();

    public Vector3 xiang_liang = new Vector3();
    public Vector3 xiang_liang2;//转化后的向量



    public float vector3_ju_li;
    public float speed;


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

            speed = (vector3_ju_li / (endtime - begintime))/10;//取得速度
            if(speed <= 100)
            {
                speed = 100;
            }
            if(speed >= 500)
            {
                speed = 500;
            }

        }



        if (Time.time <= endtime+0.1 )
        {
            
            force1 = xiang_liang2 * speed * force;
            GetComponent<Rigidbody2D>().AddForce(force1);
        }
    }

    
}
