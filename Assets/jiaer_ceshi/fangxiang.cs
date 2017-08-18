using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fangxiang : MonoBehaviour {
    public static Vector3 position2;
    public Vector3 fangxiang1;
    private void OnMouseExit()
    {
        position2 = Input.mousePosition;
        Debug.Log("2");
        fangxiang1 = position2 - yuanquanceshi.position1;
    }
    
}
