using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IKController : MonoBehaviour{
    protected Animator animator;

    public bool ikActive = true;
    public GameObject rightHandObj = null;
    public GameObject leftHandObj = null;
    public GameObject rightFootObj = null;
    public GameObject leftFootObj = null;
    public GameObject lookObj = null;
    public GameObject waistObj = null;

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        lookObj = GameObject.Find("LookTarget");
        waistObj = GameObject.Find("WaistTarget");
        rightHandObj = GameObject.Find("RHTarget");
        leftHandObj = GameObject.Find("LHTarget");
        rightFootObj = GameObject.Find("RFTarget");
        leftFootObj = GameObject.Find("LFTarget");
    }

    void OnAnimatorIK(){
        if(animator){
            if(ikActive){
                if(waistObj != null){
                    animator.bodyPosition = waistObj.transform.position;
                    animator.bodyRotation = waistObj.transform.rotation;
                }
                if(lookObj != null) {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.transform.position);
                }
                if(rightHandObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand,1);  
                    animator.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.transform.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.transform.rotation);
                }
                if(leftHandObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
                    animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.transform.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.transform.rotation);
                }
                if(rightFootObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot,1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightFoot,1);  
                    animator.SetIKPosition(AvatarIKGoal.RightFoot,rightFootObj.transform.position);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot,rightFootObj.transform.rotation);
                }
                if(leftFootObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot,1);  
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot,leftFootObj.transform.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot,leftFootObj.transform.rotation);
                }
            }else{
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,0);
                animator.SetIKPositionWeight(AvatarIKGoal.RightFoot,0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightFoot,0);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot,0);
                animator.SetLookAtWeight(0);
            }
        }

    }

}
