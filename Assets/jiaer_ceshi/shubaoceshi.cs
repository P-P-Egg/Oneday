using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shubaoceshi : MonoBehaviour
{
    private Vector3 begin = new Vector3();
    private Vector3 end = new Vector3();
    private float begintime = new float();
    private float endtime = new float();
    public float force = 10000;
    public Vector3 force1 = new Vector3();
    public Vector3 force2 = new Vector3();
    private void FixedUpdate()
    {
        lidu();

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
            force1 = (end - begin) * (1/(endtime - begintime)) * force;
        }
        if (Time.time <= endtime+0.1 )
        {
            GetComponent<Rigidbody2D>().AddForce(force1);
        }
    }

 
}
