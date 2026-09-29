using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicController : MonoBehaviour
{
    private GameObject selector;
    private Dropdown dropdown;

    public float micVolume = 0f;
    public int sampleWindow = 256;
    public float volumeScale = 20f;

    private AudioClip microphoneClip;

    private List<string> dropOptions = new List<string>();
    private string deviceName = "";
    private int micIndex = 0;
    private bool isRecoding = false;

    // Start is called before the first frame update
    void Start()
    {
        selector = GameObject.Find("MicDropdown");
        dropdown = selector.GetComponent<Dropdown>();

        if(Microphone.devices.Length == 0){
            return;
        }

        foreach(string device in Microphone.devices){
            dropOptions.Add(device);
        }

        dropdown.AddOptions(dropOptions);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRecoding){
            return;
        }
        if(microphoneClip == null){
            return;
        }
        micVolume = GetCurrentVolume();
        if(micVolume > 1f){
            micVolume = 1f;
        }
    }

    private float GetCurrentVolume(){
        float[] waveData = new float[sampleWindow];
        int micPosition = Microphone.GetPosition(deviceName);

        if(micPosition < sampleWindow){
            return 0f;
        }

        microphoneClip.GetData(waveData, micPosition - sampleWindow);

        float sum = 0f;

        for(int i=0; i < sampleWindow; i++){
            sum += waveData[i] * waveData[i];
        }

        float rms = Mathf.Sqrt(sum / sampleWindow);


        return Mathf.Clamp01(rms * volumeScale);
    }

    public float GetMicVolume(){
        return micVolume;
    }

    public void SetMicGain(float newGain){
        volumeScale = newGain;
    }

    public void SetMicIndex(int index){
        micIndex = index;

        deviceName = Microphone.devices[micIndex];
        
        microphoneClip = Microphone.Start(deviceName, true, 10, 44100);
        isRecoding = true;
    }

    void OnDestroy(){
        if(isRecoding){
            Microphone.End(deviceName);
            isRecoding = false;
            
        }
    }
}
