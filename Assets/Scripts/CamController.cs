using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private GameObject camparent;

    private float roty = 180f;
    private float posy = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        camparent = GameObject.Find("CameraParent");
    }

    // Update is called once per frame
    void Update()
    {
        camparent.transform.rotation = Quaternion.Euler(0, roty, 0);
        camparent.transform.position = new Vector3(0, posy, 0);
    }

    public void SetPan(float angle){
        roty = angle;
    }
    public void SetHeight(float height){
        posy = height;
    }
}
