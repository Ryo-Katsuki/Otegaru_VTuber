using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookController : MonoBehaviour {
    private GameObject vrminstance = null;
    protected Animator animator;
    private Transform neck;

    private GameObject udprec;
    private OpentrackUdpReceiver udpreceiver;

    private float trackgain = 1f;

    public void SetUp(){
        vrminstance = GameObject.Find("VRM1");
        animator = vrminstance.GetComponent<Animator>();
        neck = animator.GetBoneTransform(HumanBodyBones.Neck);

        udprec = GameObject.Find("UDP");
        udpreceiver = udprec.GetComponent<OpentrackUdpReceiver>();
    }

    void LateUpdate(){
        if(vrminstance != null){
            neck.localRotation = Quaternion.Euler(udpreceiver.GetPitch() * -trackgain, udpreceiver.GetYaw() * trackgain, udpreceiver.GetRoll() * trackgain);
        }
    }

    public void SetTrackGain(float newGain){
        trackgain = newGain;
    }

}
