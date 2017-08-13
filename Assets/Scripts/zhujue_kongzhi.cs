using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhujue_kongzhi : MonoBehaviour {

    public Vector3 begin = new Vector3();
    public Vector3 end = new Vector3();
    [SerializeField]
    public static  float  forcetest = 100;
    void FixedUpdate()
    {
        float force = forcestrength(begin, end);
        Vector3 fang = fangxiang(begin, end);
        GetComponent<Rigidbody2D>().AddForce(fang * force);
    }

    public Vector3 fangxiang(Vector3 a, Vector3 b)
    {
        while (moveSingleTouch())
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                a = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                b = Input.GetTouch(0).position;
            }
        }
        return b - a;
    }
    /**
     * 判断是否为单点触摸
    **/
    public static bool singleTouch()
    {
        if (Input.touchCount == 1)
            return true;
        return false;
    }

    /**
     * 判断单点触摸条件下  是否为移动触摸
     **/
    public static bool moveSingleTouch()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
            return true;
        return false;
    }

    public static float forcestrength(Vector3 p1,Vector3 p2)
    {

        while (moveSingleTouch())
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                p1 = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                p2 = Input.GetTouch(0).position;
            }
        }
        return (p1 - p2).magnitude * forcetest;
    }
}
