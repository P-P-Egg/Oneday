﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class guan_li : MonoBehaviour {

    //private Text lin_shi_t;
    //public int a;
    //public int b;

    //public int yi_ci = 1;
    //public AudioClip an_jian;

    // Use this for initialization
    void Start() {

        //zhu_jue_pz zj = new zhu_jue_pz();

        //int a = PlayerPrefs.GetInt("juli", 0);
        //////b = a;
        //lin_shi_t.text = "Best: " + a + " m";

    }

    // Update is called once per frame
    void Update() {

        //AudioSource.PlayClipAtPoint(an_jian, transform.position);


        //PlayerPrefs.SetInt("lishi", a);
        //b = PlayerPrefs.GetInt("lishi", 0);


    }

    public void OnNewGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnTop10()
    {
        SceneManager.LoadScene("Top10");
    }

    public void OnCredits()
    {
        SceneManager.LoadScene("zhi_zuo");
    }

    public void Onjiao_cheng()
    {
        SceneManager.LoadScene("jiao_cheng");
    }


}
