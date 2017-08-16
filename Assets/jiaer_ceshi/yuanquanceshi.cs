using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuanquanceshi : MonoBehaviour {

    public GameObject prefab;
    private void Update()
    {
        yuanquan();
    }
    public void yuanquan()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(prefab, pos, Quaternion.identity);
        }

    }

}
