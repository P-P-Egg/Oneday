using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jie_paihang : MonoBehaviour
{

    public paihang jiemian = new paihang();
    void Awake()
    {
        jiemian = (paihang)IOHelper.GetData(Application.persistentDataPath + "/Save" + "/GameData.sav", typeof(paihang));
        GetComponent<Text>().text = jiemian.fenshu1.ToString() + "m\n" + jiemian.fenshu2.ToString() + "m\n" + jiemian.fenshu3.ToString()+"m";
        if (jiemian.houtiao == 1)
        {
            GameObject.FindWithTag("negative").GetComponent<Text>().text = "Negative length\n" + jiemian.houtiaofenshu+"m";
        }
    }
}