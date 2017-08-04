using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chong : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void chong_zhi()//开始游戏，重新开始游戏
    {
        SceneManager.LoadScene("Main");
    }

    public void cai_dan()
    {
        SceneManager.LoadScene("jie_mian");
    }
}

