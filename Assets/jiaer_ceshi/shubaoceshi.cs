using System.Collections;
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

    public AudioClip tiao_yinxiao; //跳起后的音效


    public Vector3 xiang_liang = new Vector3();
    public Vector3 xiang_liang2;//转化后的向量
    public float grivate;

    public float vector3_ju_li;
    private float speed;
    //public bool ce_shi = true;

    private float time1 = 0;//取消重力的计时器
    private int tiao_panding = 0; //判定二段跳
    /*    private Animator anim;*///动画

    private Animator tiao_dong_hua;
    public bool dong_hua_bool = false;

    public static bool jie_shu = true;

    void Start()
    {
        grivate = GetComponent<Rigidbody2D>().gravityScale;
        tiao_dong_hua = GetComponent<Animator>(); 
    }
    void Update()//如果用FixedUpdate会导致偶尔操作不触发
    {
        if(jie_shu == true)//判断游戏是否失败
        {
            tiao_yue();
        }
        
   
        //lidu();
    }


    private void FixedUpdate()
    {
        //lidu();
        tiao_donghua();

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
            //doubi.haha = true;

            if (vector3_ju_li >= 5) //二段跳的判断，如果滑动屏幕少于5 则不计算
            {
                tiao_panding += 1;
            }

            endtime = Time.time;

            end = Input.mousePosition;

            xiang_liang = end - begin;//取得向量

            xiang_liang2 = Vector3.Normalize(xiang_liang);//向量转化为单位向量

            vector3_ju_li = Vector3.Distance(end, begin);//取得两点距离

            speed = vector3_ju_li;//取得速度
            if(speed <= 400)
            {
                speed = 400;
            }
            if(speed >= 880)
            {
                speed = 880;
            }



            /*GetComponent<Rigidbody2D>().gravityScale = 0;*///取消重力
        }



        if (Time.time < endtime + 0.2)
        {
            force1 = xiang_liang2 * speed * force;
            /*GetComponent<Rigidbody2D>().gravityScale = 0;*///取消重力
            if(vector3_ju_li >= 5) //如果滑动屏幕少于5 则不施加力
            {
                AudioSource.PlayClipAtPoint(tiao_yinxiao, transform.position);
                dong_hua_bool = true;
                GetComponent<Rigidbody2D>().AddForce(force1);
            }
            


        }

        //if (Time.time >= endtime + 0.2 || Time.time <= endtime + 1)
        //{

        //    GetComponent<Rigidbody2D>().gravityScale = 10;//重启重力

        //}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Road")
        {
            dong_hua_bool = false;
        }

    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Road")
        {
            
            tiao_panding = 0;

            //doubi.haha = false;
        }
    }

    void tiao_yue () // 跳跃判定的方法
    {
        if(tiao_panding < 2)
        {
            lidu();

            //doubi.haha = true;
        }
    }

    void tiao_donghua() //动画控制
    {
        tiao_dong_hua.SetBool("dh_bool", dong_hua_bool);
        tiao_dong_hua.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
    }
}
