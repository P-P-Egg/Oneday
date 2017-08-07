using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiang_ji_gensui : MonoBehaviour
{

    public Transform zhu_jue;
    public int[] arr;
    public LinkedList<int> l;
    //private Vector3 pian_yi;//偏移
    private float weizhi_x;
    private Vector3 pian_yi;


    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(1334, 750, true);
        pian_yi = transform.position - zhu_jue.position;
        SaveData.load();
    }

    // Update is called once per frame
    void Update()
    {
        weizhi_x = zhu_jue.position.x;
        transform.position = new Vector3(weizhi_x + pian_yi.x, 0, -10);
        arr = SaveData.data;
        l = SaveData.Distance;
    }
}
