    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bei_hou1 : MonoBehaviour
{
    public Transform road1;
    public Transform zhu_jue;
    public GameObject[] road;// 路的数组
    public GameObject[] qj_shuye1;//前景树叶的数组
    public GameObject[] yun_sz;//云的数组
    public GameObject[] teng_sz;//藤曼的数组
    public GameObject[] shu_sz;//树的数组
    public GameObject[] sky_sz;
    public GameObject[] qj_shan_sz;
    public GameObject[] bj_shan_sz;


    public List<GameObject> lu = new List<GameObject>();//创建的路
    public List<GameObject> sky = new List<GameObject>();//创建的天
    public List<GameObject> qj_shan = new List<GameObject>();//前景山
    public List<GameObject> bj_shan = new List<GameObject>();//背景山
    public List<GameObject> qj_shuye = new List<GameObject>();//前景树叶
    public List<GameObject> yun = new List<GameObject>();//云
    public List<GameObject> teng = new List<GameObject>();//藤曼
    public List<GameObject> shu = new List<GameObject>();//树

    //private Vector3 wei_zhi; //第一个路的位置
    private Vector3 xin_weizhi;//新路的位置
    private Vector3 zhu_jue_wz;//主角位置
    private Vector3 chuang_lu;
    private Vector3 zui_xin;

    private Vector3 sky_weizhi;//天空位置
    private Vector3 qj_shan_wz;//前景山位置
    private Vector3 bj_shan_wz;//背景山位置
    private Vector2 qj_shuye_wz;//前景树叶位置
    private Vector3 yun_wz;//云的位置
    private Vector3 teng_wz;//藤曼的位置

    private GameObject dao_lu;
    private GameObject sky1;//天空物体
    private GameObject xiao_lu;

    private int yi_ci = 1;
    private int yi_ci_sky = 1;
    private int yi_ci_qjshan = 1;
    private int yi_ci_bjshan = 1;
    private int yi_ci_qjshuye = 1;
    private int yi_ci_yun = 1;
    private int yi_ci_teng = 1;
    private int yi_ci_shu = 1;

    //private Vector3 chuang_lu;//最新创建路的位置

    // Use this for initialization
    void Start()
    {
        //wei_zhi = road1.position;//第一个路的位置


    }

    // Update is called once per frame
    void Update()
    {
        //取得主角的位置
        zhu_jue_wz = zhu_jue.transform.position;

        //白天的方法
        ping_tai_bt();
        sky_bai();
        qj_shan_ff();
        bj_shan_ff();
        qj_shuye_ff();
        yun_ff();
        teng_ff();


    }

    private void ping_tai_bt()//地图生成
    {
        //随机取得一个路
        int sui_ji = Random.Range(0, 5);
        dao_lu = road[sui_ji];
        //只执行一次
        Vector3 pos = new Vector3(-49.2f, -10.8f, 0);
        if (yi_ci == 1)
        {
            GameObject go = GameObject.Instantiate(dao_lu, /*wei_zhi + */pos, Quaternion.identity) as GameObject;
            lu.Add(go);
            yi_ci = 0;
        }
        //随机取得一个位置
        //路的大小最大，10米，9米，8米，7米，6米，5米，最小间隔18（3米——11米）
        //并取得最新生成路的位置
        float suji_wei = Random.Range(-12f, -21f);
        float suiji_y = Random.Range(-11.5f, 1f);
        xin_weizhi = new Vector3(suji_wei, 0, 0);//随机X轴增加的多少
        int x = lu.Count - 1;
        chuang_lu = lu[x].transform.position;//最新创建路的位置
        zui_xin = xin_weizhi + chuang_lu;
        zui_xin.y = suiji_y;

        //随机生成一个路
        if (lu.Count <= 15)
        {
            xiao_lu = GameObject.Instantiate(dao_lu, zui_xin, Quaternion.identity) as GameObject;
            lu.Add(xiao_lu);
            //在路的基础上建立一个树
            if (sui_ji == 0)
            {
                int a0 = Random.Range(0, 4);
                if (a0 <= 2)
                {
                    int a0_suiji = Random.Range(0, 6);
                    float a0_x = Random.Range(-3f, 3f);
                    GameObject shu_1 = GameObject.Instantiate(shu_sz[a0_suiji], new Vector3(a0_x, 2.5f) + xiao_lu.transform.position, Quaternion.identity) as GameObject;
                    shu.Add(shu_1);
                    if (a0 == 0)
                    {
                        a0_suiji = Random.Range(0, 2);
                        a0_x = Random.Range(-3f, 3f);
                        shu_1 = GameObject.Instantiate(shu_sz[a0_suiji], new Vector3(a0_x, 2.5f) + xiao_lu.transform.position, Quaternion.identity) as GameObject;
                        shu.Add(shu_1);
                    }
                }
            }
            if (sui_ji == 1)
            {
                int a0 = Random.Range(0, 4);
                if (a0 <= 1)
                {
                    int a0_suiji = Random.Range(0, 6);
                    float a0_x = Random.Range(-2f, 2f);
                    GameObject shu_1 = GameObject.Instantiate(shu_sz[a0_suiji], new Vector3(a0_x, 2.5f) + xiao_lu.transform.position, Quaternion.identity) as GameObject;
                    shu.Add(shu_1);
                }
            }
            if (sui_ji == 2)
            {
                int a0 = Random.Range(0, 5);
                if (a0 <= 1)
                {
                    int a0_suiji = Random.Range(0, 6);
                    float a0_x = Random.Range(-1.5f, 1.5f);
                    GameObject shu_1 = GameObject.Instantiate(shu_sz[a0_suiji], new Vector3(a0_x, 2.5f) + xiao_lu.transform.position, Quaternion.identity) as GameObject;
                    shu.Add(shu_1);
                }
            }
            if (sui_ji == 3)
            {
                int a0 = Random.Range(0, 5);
                if (a0 <= 1)
                {
                    int a0_suiji = Random.Range(0, 6);
                    float a0_x = Random.Range(-1f, 1f);
                    GameObject shu_1 = GameObject.Instantiate(shu_sz[a0_suiji], new Vector3(a0_x, 2.5f) + xiao_lu.transform.position, Quaternion.identity) as GameObject;
                    shu.Add(shu_1);
                }
            }
            if (sui_ji == 4)
            {
                int a0 = Random.Range(0, 5);
                if (a0 <= 1)
                {
                    int a0_suiji = Random.Range(0, 6);
                    float a0_x = Random.Range(1f, 1.8f);
                    GameObject shu_1 = GameObject.Instantiate(shu_sz[a0_suiji], new Vector3(a0_x, 2.5f) + xiao_lu.transform.position, Quaternion.identity) as GameObject;
                    shu.Add(shu_1);
                }
            }
        }
        //后方距离主角太远的路会被删除
        if (lu[0] != null)
        {
            if (zhu_jue_wz.x - lu[0].transform.position.x <= -150)
            {
                GameObject.Destroy(lu[0]);
                lu.RemoveAt(0);
                shu_ff();
            }
        }
    }

    public void sky_bai()
    {
        //sky_weizhi = sky[0].transform.position;
        //sky1 = sky[0];
        if (yi_ci_sky == 1)
        {
            GameObject go = GameObject.Instantiate(sky_sz[0], new Vector3(-57.6f, 1.7f, 0), Quaternion.identity) as GameObject;
            sky.Add(go);
            yi_ci_sky = 0;
        }
        int x = sky.Count - 1;
        sky_weizhi = sky[x].transform.position;
        if (sky.Count <= 8)
        {
            GameObject sky_1 = GameObject.Instantiate(sky_sz[0], new Vector3(-50, 0, 0) + sky_weizhi, Quaternion.identity) as GameObject;
            sky.Add(sky_1);
        }
        if (sky[0] != null)
        {
            if (zhu_jue_wz.x - sky[0].transform.position.x <= -150)
            {
                GameObject.Destroy(sky[0]);
                sky.RemoveAt(0);
            }
        }
    }

    public void qj_shan_ff()
    {

        if (yi_ci_qjshan == 1)
        {
            GameObject go = GameObject.Instantiate(qj_shan_sz[0], new Vector3(-53.6f, -10.65f, 0), Quaternion.identity) as GameObject;
            qj_shan.Add(go);
            yi_ci_qjshan = 0;
        }
        int x = qj_shan.Count - 1;
        qj_shan_wz = qj_shan[x].transform.position;
        if (qj_shan.Count <= 10)
        {
            GameObject qj_shan1 = GameObject.Instantiate(qj_shan_sz[0], new Vector3(-38.48f, 0, 0) + qj_shan_wz, Quaternion.identity) as GameObject;
            qj_shan.Add(qj_shan1);
        }
        if (qj_shan[0] != null)
        {
            if (zhu_jue_wz.x - qj_shan[0].transform.position.x <= -180)
            {
                GameObject.Destroy(qj_shan[0]);
                qj_shan.RemoveAt(0);
            }
        }
    }

    public void bj_shan_ff()
    {

        float suiji_x = Random.Range(-20f, -40f);
        //float suiji_xx = Random.Range(-14f, -2f);
        if (yi_ci_bjshan == 1)
        {
            GameObject go = GameObject.Instantiate(bj_shan_sz[0], new Vector3(-48.2f, -5f, 0), Quaternion.identity) as GameObject;
            bj_shan.Add(go);
            yi_ci_bjshan = 0;
        }
        int x = bj_shan.Count - 1;
        bj_shan_wz = bj_shan[x].transform.position;
        if (bj_shan.Count <= 10)
        {
            GameObject bj_shan1 = GameObject.Instantiate(bj_shan_sz[0], new Vector3(suiji_x, 0, 0) + bj_shan_wz, Quaternion.identity) as GameObject;
            bj_shan.Add(bj_shan1);
        }
        if (bj_shan[0] != null)
        {
            if (zhu_jue_wz.x - bj_shan[0].transform.position.x <= -150)
            {
                GameObject.Destroy(bj_shan[0]);
                bj_shan.RemoveAt(0);
            }
        }
    }

    public void qj_shuye_ff()
    {
        int suiji_a = Random.Range(0, 3);
        if (yi_ci_qjshuye == 1)
        {
            GameObject go = GameObject.Instantiate(qj_shuye1[suiji_a], new Vector2(-52.6f, -12.09f), Quaternion.identity) as GameObject;
            qj_shuye.Add(go);
            yi_ci_qjshuye = 0;
        }
        int x = qj_shuye.Count - 1;
        qj_shuye_wz = qj_shuye[x].transform.position;
        float suiji_x = Random.Range(-33f, -35f);
        if (qj_shuye.Count <= 10)
        {
            GameObject sky_1 = GameObject.Instantiate(qj_shuye1[suiji_a], new Vector2(suiji_x, 0) + qj_shuye_wz, Quaternion.identity) as GameObject;
            qj_shuye.Add(sky_1);
        }
        if (qj_shuye[0] != null)
        {
            if (zhu_jue_wz.x - qj_shuye[0].transform.position.x <= -150)
            {
                GameObject.Destroy(qj_shuye[0]);
                qj_shuye.RemoveAt(0);
            }
        }
    }

    public void yun_ff()
    {
        int suiji_a = Random.Range(0, 5);
        if (yi_ci_yun == 1)
        {
            GameObject go = GameObject.Instantiate(yun_sz[suiji_a], new Vector2(-74.8f, 0f), Quaternion.identity) as GameObject;
            yun.Add(go);
            yi_ci_yun = 0;
        }
        int x = yun.Count - 1;
        yun_wz = yun[x].transform.position;
        float suiji_x = Random.Range(-20f, -50f);
        float suiji_y = Random.Range(-3, 15);
        if (yun.Count <= 14)
        {
            GameObject sky_1 = GameObject.Instantiate(yun_sz[suiji_a], new Vector2(suiji_x + yun_wz.x, suiji_y), Quaternion.identity) as GameObject;
            yun.Add(sky_1);
        }
        if (yun[0] != null)
        {
            if (zhu_jue_wz.x - yun[0].transform.position.x <= -150)
            {
                GameObject.Destroy(yun[0]);
                yun.RemoveAt(0);
            }
        }
    }

    public void teng_ff()
    {
        int suiji_a = Random.Range(0, 2);
        if (yi_ci_teng == 1)
        {
            GameObject go = GameObject.Instantiate(teng_sz[suiji_a], new Vector2(-52.6f, 11.4f), Quaternion.identity) as GameObject;
            teng.Add(go);
            yi_ci_teng = 0;
        }
        int x = teng.Count - 1;
        teng_wz = teng[x].transform.position;
        float suiji_x = Random.Range(-15f, -50f);
        float suiji_y = Random.Range(10.75f, 13.5f);
        if (teng.Count <= 12)
        {
            GameObject sky_1 = GameObject.Instantiate(teng_sz[suiji_a], new Vector3(suiji_x + teng_wz.x, suiji_y), Quaternion.identity) as GameObject;
            teng.Add(sky_1);
        }
        if (teng[0] != null)
        {
            if (zhu_jue_wz.x - teng[0].transform.position.x <= -150)
            {
                GameObject.Destroy(teng[0]);
                teng.RemoveAt(0);
            }
        }
    }

    public void shu_ff()
    {
        //if (yi_ci_shu == 1)
        //{
        //    GameObject go = GameObject.Instantiate(shu_sz[0], new Vector2(-21, -50), Quaternion.identity) as GameObject;
        //    teng.Add(go);
        //    yi_ci_shu = 0;
        //}
        if (shu[0] != null)
        {
            if (zhu_jue_wz.x - shu[0].transform.position.x <= -150)
            {
                GameObject.Destroy(shu[0]);
                shu.RemoveAt(0);
            }
        }
    }

}
