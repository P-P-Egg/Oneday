using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banjing : MonoBehaviour {
    public Vector3[] point = new Vector3[10];
    public float length;
    public int i;
    void Start()
    {
        i = 0;
        length = 0;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            point[i]= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            i++;
        }
        if (i >1)
        {
            length = (point[i] - point[i - 1]).magnitude;
        }
    }

}
