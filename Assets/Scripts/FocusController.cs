using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusController : MonoBehaviour
{
    private GameObject canvasobject;
    private Canvas canvas = null;

    // Start is called before the first frame update
    void Start(){

        canvasobject = GameObject.Find("Canvas");
        canvas = canvasobject.GetComponent<Canvas>();

    }

    void OnApplicationFocus(bool hasFocus){

        if(canvas != null){
            canvas.enabled = hasFocus;
        }

    }
}
