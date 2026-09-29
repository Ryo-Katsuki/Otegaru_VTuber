using System.Collections;
using System.IO;
using UnityEngine;
using UniVRM10;

public class LoadVRM : MonoBehaviour{

    public void ClickLoadButton(){
        string path = OpenFileDialog.OpenVRMFileDialog();
        LoadVRMModel(path);
    }

    async void LoadVRMModel(string path){
        if (!File.Exists(path)){
            return;
        }

        Vrm10Instance instance = await Vrm10.LoadPathAsync(path);

        if (instance == null){
            return;
        }

        instance.transform.SetParent(this.transform);
        instance.transform.localPosition = Vector3.zero;
    }
}