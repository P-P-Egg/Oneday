using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;


public class paihang
{
    public int fenshu1;
    public int fenshu2;
    public int fenshu3;
    public int houtiao;
    public int houtiaofenshu;
    public List<int> Ints = new List<int>()
        {
            1,
            2,
            3,
            4,
            5
        };
}



public class zhu_jue_pz : MonoBehaviour {

    private Rigidbody2D rigidbody2D;
    public float su_du = 2f; //调整保持速度

    public AudioClip an_jian;//跳起和按键音效
    public AudioClip peng_zhuang;

    public Vector3 zhu_jue_wz;
    public float timer = 1;
    public float su_lv = 1;
    public int zhen_jia = 1;
    public int qian_xing = 1;

    public bool a = false;

    public float linshi_jishi = 0;

    public Slider xu_li_slider;//UI血条
    public Transform jian_tou;//箭头

    private float xu = 100;
    private float li = 100;
    
    public int ju_li2;

    private Text lu_text;//判断距离的text
    private Text jieshu_text;//游戏结束的text
    
    private Image jieshu_image;//游戏结束的image
    private Button chong_button;//重置的按钮
    private Button zan_ting;//暂停按钮
    private Button cai_dan;//菜单按钮
    private Animator dong_hua;//动画

    private float kong_zhong;//控制停留的时间

    public Vector3 shu_biao;//得到鼠标的世界位置想办法
    public Vector3 shu_biao2;
    public float jue_du;//箭头指向的角度
    public float turnSpeed = 10f;

    public float y_qian;
    public float y_hou;
    private float go;
    public bool jin_yong = true;
    private float ji_shi1 = 0;
    private int yi_ci = 1;
    private static int[] paihang=new int[] { 0, 0, 0 };//排行榜的个数
    public paihang a1 = new paihang();
    public float qsu_du = 200;
    // Use this for initialization

    private void Awake()
    {
        dudang();        
    }

    void Start () {
        
        lu_text = GameObject.Find("lu_Text").GetComponent<Text>();
        jieshu_text = GameObject.Find("jieshu_Text").GetComponent<Text>();

        zan_ting = GameObject.Find("zanting_Button").GetComponent<Button>();

        jieshu_image = GameObject.Find("jieshu_Image").GetComponent<Image>();
        jieshu_image.gameObject.SetActive(false);

        rigidbody2D = GetComponent<Rigidbody2D>();
        chong_button = GameObject.Find("chong_Button").GetComponent<Button>();
        chong_button.gameObject.SetActive(false);
        cai_dan = GameObject.Find("caidan_Button").GetComponent<Button>();
        cai_dan.gameObject.SetActive(false);
        dong_hua = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
        xu_li_slider.value = (timer * 10f) / xu;

        if (Input.GetMouseButtonUp(0))
        {
          qian_xing = 0;
        }



        si_wang();

        //xu_li();


        //tiao();

        
        //jian_tou_zhixiang();
    }

    void LateUpdate()
    {
        //xu_li();
        //tiao();
    }

    void FixedUpdate() //固定频率调用
    {
        zhu_jue_wz = transform.position;//即时得到了主角的位置
        //Debug.Log(zhu_jue_wz);
        ju_li2 = Convert.ToInt32(zhu_jue_wz.x + 8.4f);
        lu_text.text = ju_li2 + " m";
        if (jin_yong == true && qian_xing == 1)
        {
            bao_chi();
        }
        //bao_chi();

        //根据移动的距离提高主角移动速度
        //if(ju_li2 >= 200)
        //{
        //    su_du = 2.5f;
        //}
        //else if(ju_li2 >= 400)
        //{
        //    su_du = 3f;
        //}
        //else if(ju_li2 >= 600)
        //{
        //    su_du = 3.5f;
        //}
        //else if(ju_li2 >= 800)
        //{
        //    su_du = 4f;
        //}



        //jishi();

        //dong_hua_p();

    }

    void OnCollisionEnter2D(Collision2D coll)
    {        
        if (coll.gameObject.tag == "Road")
        {

            AudioSource.PlayClipAtPoint(peng_zhuang, transform.position);
            rigidbody2D.velocity = new Vector2(0.3f,0);
            qian_xing = 1;
            a = false;
            jin_yong = true;
            //dong_hua.SetTrigger("xia_luo_js");
        }
    }


    void OnCollisionStay2D(Collision2D coll) // 保持主角向前移动的条件
    {
        if(coll.gameObject.tag == "Road")//判断是否在路上
        {
            
            zhen_jia = 1;
            qian_xing = 1;
            a = false;
            //dong_hua.SetTrigger("xia_luo_js");
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Road")
        {
            zhen_jia = 0;
            qian_xing = 0;
            a = true;
        }
    }

    void qian_jing()//推动主角前进的力
    {
        rigidbody2D.AddForce(new Vector2(1, 0)*qsu_du);//修改成负数了 20170805 我又改正数了
    }
    
    void xu_li()//弹跳蓄力
    {
        if (Input.GetMouseButton(0) )//蓄力，任何时候都可以蓄力
        {

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if(Physics.Raycast(ray, out hit))
            //{
                //if (hit.transform.tag == "zan_ting")
                //{
                     //ji_shi();
                //}
            //}


           ji_shi();


        }
        //if (Input.GetKey("o"))
        //{
        //    dong_hua.SetTrigger("tiao_qi_js");
        //}
    }

    void tiao()//跳起
    {   
        if (Input.GetMouseButtonUp(0))//跳起，放开后蓄力消失，但是只有接触到地面才会跳
        {
            if (zhen_jia == 1)
            {
                
                //rigidbody2D.velocity = new Vector2(0, 0);
                //Thread.Sleep(50);
                //rigidbody2D.velocity = new Vector2(1f, 1f) * timer;
                jin_yong = false;
                ji_shi1 += Time.time;
                if(ji_shi1 >= 1)
                {

                    AudioSource.PlayClipAtPoint(an_jian, transform.position);
                    rigidbody2D.AddForce(shu_biao2 * timer * 200f);
                    ji_shi1 = 0;
                }
                        
            }
                //kong_zhong = timer / 5f; //10的力会在空中停留2秒，所以空中停留时间与力的比例是1比5
                //dong_hua.speed = 1.083f / kong_zhong;
                //if (timer > 2)
                //{
                //    dong_hua.SetTrigger("tiao_qi");
                //}
        
            timer = 1;
            //zhen_jia = 0;
        }  
    }

    void bao_chi()//主角保持前进的速度
    {
        qian_jing();
        Vector2 velocity = rigidbody2D.velocity;
        if (velocity.x >= 0.1)
        {
            velocity.x = 1f * su_du;
            rigidbody2D.velocity = velocity;
        }
        //Debug.Log(velocity.x);
    }

    void ji_shi()
    {
        timer = Time.deltaTime * su_lv + timer;// 蓄力的时间
        if(timer >= 10)
        {
            timer = 10;
        }
    }

    public void si_wang()//游戏结束
    {
        if(zhu_jue_wz.y <= -15)
        {
            if(yi_ci == 1)
            {
                //guan_li gl = new guan_li();

                jieshu_image.gameObject.SetActive(true);
                rigidbody2D.velocity = new Vector2(0, 0);
                jieshu_text.text = "Game over, moved " + ju_li2 + " m";
                paihangbangshuju();
                cundang();
                //Debug.Log(a1.fenshu1);
                //Debug.Log(a1.fenshu2);
                //Debug.Log(a1.fenshu3);
                //int go = ju_li;
                //PlayerPrefs.SetInt("juli", go);
                chong_button.gameObject.SetActive(true);
                cai_dan.gameObject.SetActive(true);
                yi_ci = 0;
                //SceneManager.LoadScene("Main");
            }

        } 
    }

    public void jian_tou_zhixiang()//箭头跟随的方法
    {
        //Vector3 shu_biao_y = shu_biao;
        //shu_biao_y.y = shu_biao.y;
        //jian_tou.transform.rotation = Quaternion.LookRotation(shu_biao);
        //jian_tou.transform.LookAt(shu_biao2);
        shu_biao = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        shu_biao2 = shu_biao - jian_tou.transform.position;
        shu_biao2.z = 0f;
        shu_biao2.Normalize();
        jue_du = Mathf.Atan2(shu_biao2.y, shu_biao2.x) * Mathf.Rad2Deg;
        //if (jue_du >= 65)
        //{
        //    jue_du = 65;
        //}
        //if (jue_du <= 10)
        //{
        //    jue_du = 10;
        //}
        jian_tou.transform.rotation = Quaternion.Slerp(jian_tou.transform.rotation, Quaternion.Euler(0, 0, jue_du), turnSpeed * Time.deltaTime);

        // 赋予跳的方向值



    }
    public void paihangbangshuju()//排行榜
    {
        if (ju_li2 > a1.fenshu1&&ju_li2>=0)
        { 
            a1.fenshu3 = a1.fenshu2;
            a1.fenshu2 = a1.fenshu1;
            a1.fenshu1 = ju_li2;

        }
        else if (ju_li2 > a1.fenshu2 && ju_li2 <= a1.fenshu1&&ju_li2>=0)
        {
            a1.fenshu3 = a1.fenshu2;
            a1.fenshu2 = ju_li2;
        }
        else if (ju_li2 > a1.fenshu3 && ju_li2 <= a1.fenshu2&&ju_li2>=0)
        {
            a1.fenshu3 = ju_li2;
        }
        if (ju_li2 < 0 && ju_li2 < a1.houtiaofenshu)
        {
            a1.houtiao = 1;
            a1.houtiaofenshu = ju_li2;
        }
    }
    public void cundang()
    {
        IOHelper.CreateDirectory(Application.persistentDataPath + "/Save");
        IOHelper.SetData(Application.persistentDataPath + "/Save" + "/GameData.sav", a1);
    }

    public void dudang()
    {
        if (!IOHelper.IsFileExists(Application.persistentDataPath + "/Save" + "/GameData.sav"))
        {
            a1.fenshu1 = 0;
            a1.fenshu2 = 0;
            a1.fenshu3 = 0;
            a1.houtiao = 0;
            a1.houtiaofenshu = 0;
        }
        else
        {
            a1= (paihang)IOHelper.GetData(Application.persistentDataPath + "/Save" + "/GameData.sav", typeof(paihang));
        }
    }
    

    //public void jishi()
    //{
    //    if (a == true)
    //    {
    //        linshi_jishi = Time.deltaTime + linshi_jishi;
    //    }
    //    if (Input.GetKey("k"))
    //    {
    //        linshi_jishi = 0;
    //    }
    //}

    //public void dong_hua_p()
    //{
    //    //go = Time.deltaTime + go;
    //    //if (go > 0.5f)
    //    //{
    //    //    y_qian = zhu_jue_wz.y;
    //    //    go = 0;
    //    //}
    //    //y_hou = zhu_jue_wz.y;
    //    //if (y_qian - y_hou > 0.8f)
    //    //{
    //    //    dong_hua.SetTrigger("xia_luo");
    //    //}
    //    //RaycastHit2D hit = Physics2D.Linecast(zhu_jue_wz, zhu_jue_wz + new Vector3(-1, -1, 0));
    //    //if (hit.collider.tag == "Road")
    //    //{
    //    //    dong_hua.SetTrigger("xia_luo_js");
    //    //}
    //}
}
