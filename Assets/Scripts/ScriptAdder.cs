using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniVRM10;

public class ScriptAdder : MonoBehaviour{

    private GameObject vrm = null;
    private Animator anim = null;
    public RuntimeAnimatorController newAnim;

    public void SetUp(){
        vrm = GameObject.Find("VRM1");
        anim = vrm.GetComponent<Animator>();
        anim.runtimeAnimatorController = newAnim; 
        vrm.AddComponent<IKController>();
        vrm.AddComponent<ExpressionController>();
    }
}