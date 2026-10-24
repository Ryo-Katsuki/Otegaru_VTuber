using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerController : MonoBehaviour
{
    private GameObject pivot;
    private GameObject moza;
    private MozaController moza_cont;
    private float angle_buffer = 0f;
    private float angle_final = 0f;
    // Start is called before the first frame update
    void Start()
    {
        pivot = GameObject.Find("Pivot");
        moza = GameObject.Find("MOZA");
        moza_cont  = moza.GetComponent<MozaController>();
    }

    // Update is called once per frame
    void Update()
    {
        angle_buffer = moza_cont.GetSteeringAngle();

        if(!float.IsNaN(angle_buffer)){
            angle_final = angle_buffer;

            if(angle_buffer > 120f){
                angle_final = 120f;
            }
            if(angle_buffer < -120f){
                angle_final = -120f;
            }

        }

        pivot.transform.rotation = Quaternion.Euler(0f, 0f, - angle_final);
    }
}
