using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huadong : MonoBehaviour
{
    private void FixedUpdate()
    {
        if(Input.GetTouch(0).phase==TouchPhase.Moved)
        {
            this.transform.Translate(1, 0, 0);
        }
    }
}
