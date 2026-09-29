using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookController : MonoBehaviour {

    private GameObject lptarget;
    private GameObject lktarget;
    private GameObject udprec;
    private OpentrackUdpReceiver udpreceiver;

    private float trackgain = 1f;

    void Start(){
        lptarget = GameObject.Find("LookParent");
        lktarget = GameObject.Find("LookTarget");

        udprec = GameObject.Find("UDP");
        udpreceiver = udprec.GetComponent<OpentrackUdpReceiver>();
    }

    void Update(){
        lptarget.transform.rotation = Quaternion.Euler(udpreceiver.GetPitch() * -1 * trackgain, udpreceiver.GetYaw() * -1 * trackgain, 0f);
        lktarget.transform.rotation = Quaternion.Euler(0f, 0f, udpreceiver.GetRoll() * -1 * trackgain);
    }

    public void SetTrackGain(float newGain){
        trackgain = newGain;
    }

}
