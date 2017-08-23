using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fangxiang : MonoBehaviour {
<<<<<<< HEAD
    public Vector3 position1;
    public Vector3 position2;
    public float time1;
    public float time2;
    public float force = 100;
    public float forcetime;
    public Vector3 lidufx;
    public float time;
    void Update()
    {
        fxld();
    }
    void  fxld()
    {
        if (Input.GetMouseButtonDown(0))
        {
            position1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            time1 = Time.time;
        }
        if (Input.GetMouseButton(0))
        {
            position2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            time2 = Time.time;
        }
        if((position2 - position1).magnitude == 14.1F)
        {
            lidufx = (position2 - position1).normalized;
            time = time1 - time2;
            forcetime = Time.time;
        }
        while (Time.time <= forcetime+0.1f)
        {
            GetComponent<Rigidbody2D>().AddForce(lidufx / time * force);
        }
    }
=======
    //public Vector3 position1;
    //public Vector3 position2;
    //Vector3  fxld()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        position1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    }
    //    if (Input.GetMouseButton(0))
    //    {
    //        position2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    }
    //    while ((position2 - position1).magnitude == 14.1F)
    //    {
    //        Vector3 lidufx = (position2 - position1).normalized;
    //    }
    //}
>>>>>>> 5c3e507122b463d51a335f5c1a5c0a6adc01a338
}
