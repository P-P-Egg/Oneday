using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class chong : MonoBehaviour {

    GameObject zan_tingUI;
    int Ui_layer;
    // Use this for initialization
    void Start () {
        Ui_layer = LayerMask.GetMask("UI");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("当前触摸在UI上");
            }  
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    Debug.Log(1);
            //}
               
        }


    }

    public void chong_zhi()//开始游戏，重新开始游戏
    {
        SceneManager.LoadScene("Main");
    }

    public void cai_dan()
    {
        SceneManager.LoadScene("jie_mian");
    }

    public void zan_ting() //暂停游戏
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    void OnMouseDow()
    {
        Debug.Log(1);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.gameObject); 

            //zan_tingUI = hit.collider.gameObject;
            //if(zan_tingUI.name == "zhu_jue")
            //{
            //    zan_ting();
            //}

        }





    }
}

