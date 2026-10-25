using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using UniVRM10;

public class LoadVRM : MonoBehaviour{

    private Vrm10Instance instance;

    private GameObject vrm = null;
    private Animator anim = null;
    public RuntimeAnimatorController newAnim;

    private GameObject upperparent;
    private LookController lookcont;

    public void ClickLoadButton(){
        string path = OpenFileDialog.OpenVRMFileDialog();
        LoadVRMModel(path);
    }

    async void LoadVRMModel(string path){
        if (!File.Exists(path)){
            return;
        }

        instance = await Vrm10.LoadPathAsync(path);

        instance.transform.SetParent(this.transform);
        instance.transform.localPosition = Vector3.zero;

        vrm = GameObject.Find("VRM1");
        anim = vrm.GetComponent<Animator>();
        anim.runtimeAnimatorController = newAnim;
        vrm.AddComponent<IKController>();
        vrm.AddComponent<ExpressionController>();

        await Task.Delay(1000);

        lookcont = GetComponent<LookController>();
        lookcont.SetUp();
    }
}
