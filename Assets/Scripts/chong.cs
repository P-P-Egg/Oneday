using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class chong : MonoBehaviour {

    GameObject zan_tingUI;
    int Ui_layer;

    /*public bool zanting_pd = true;*///完善暂停按钮
    // Use this for initialization
    void Start () {
        
        Ui_layer = LayerMask.GetMask("UI");

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButton(0))
        //{
        //    if (EventSystem.current.IsPointerOverGameObject())
        //    {
        //        if (EventSystem.current.currentSelectedGameObject.name == "zanting_Button")
        //        {
        //            zan_ting();
        //        }
        //    }
        //}
    }
        
            

        

    public void chong_zhi()//开始游戏，重新开始游戏
    {
        SaveData.New();
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
        //zanting_pd = true;
    }


}

