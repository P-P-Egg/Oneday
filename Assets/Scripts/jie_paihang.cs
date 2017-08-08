using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jie_paihang : MonoBehaviour
{

    public paihang jiemian = new paihang();
    private static string dirpath = "/Save";
    private static string filename = dirpath + "/GameData.sav";
    void Awake()
    {
        jiemian = (paihang)IOHelper.GetData(filename, typeof(paihang));
        GetComponent<Text>().text = jiemian.fenshu1.ToString() + "m\n" + jiemian.fenshu2.ToString() + "m\n" + jiemian.fenshu3.ToString()+"m";
    }
}