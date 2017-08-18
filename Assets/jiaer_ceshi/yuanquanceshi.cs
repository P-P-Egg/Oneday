using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuanquanceshi : MonoBehaviour {

    public GameObject prefab;
    public static Vector3 position1;
    private void Update()
    {
        yuanquan();
    }
    public void yuanquan()
    {
        if(Input.GetMouseButtonDown(0))
        {
            position1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(prefab, position1, Quaternion.identity);
        }
    }

}
