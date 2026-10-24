using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using mozaAPI;
using static mozaAPI.mozaAPI;

public class MozaController : MonoBehaviour
{
    private HIDData hid_data;
    private ERRORCODE errorcode;

    // Start is called before the first frame update
    void Start(){
        installMozaSDK();
    }

    // Update is called once per frame
    void Update(){
        try{
            hid_data = getHIDData(ref errorcode);
        }
        catch(Exception ex){
            Debug.Log($"HIDData error:{ex}");
            Debug.Log($"HIDData errorcode:{errorcode}");
            return;
        }
        
    }

    void OnApplicationQuit(){
        removeMozaSDK();
    }

    public float GetSteeringAngle(){
        return hid_data.fSteeringWheelAngle;
    }
}
