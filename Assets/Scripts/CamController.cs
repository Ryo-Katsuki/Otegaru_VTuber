using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private GameObject camparent;

    private float roty = 180f;
    private float posy = 1.5f;
    private Vector3 vpos;

    // Start is called before the first frame update
    void Start()
    {
        camparent = GameObject.Find("CameraParent");
    }

    // Update is called once per frame
    void Update()
    {
        vpos.Set(0f, posy, 0f);
        camparent.transform.rotation = Quaternion.Euler(0f, roty, 0f);
        camparent.transform.position = vpos;
    }

    public void SetPan(float angle){
        roty = angle;
    }
    public void SetHeight(float height){
        posy = height;
    }
}
