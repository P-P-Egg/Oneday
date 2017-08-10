using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huadong : MonoBehaviour
{

    
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

    public Vector3 fangxiang(Vector3 begin, Vector3 end)
    {
        while (moveSingleTouch())
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                begin = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                end = Input.GetTouch(0).position;
            }           
        }
        return end - begin;
    }
}
