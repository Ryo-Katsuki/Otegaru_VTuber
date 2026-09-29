using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniVRM10;

public class ExpressionController : MonoBehaviour
{
    private GameObject vrm;
    private Vrm10Instance instance;
    private Vrm10RuntimeExpression runtimeExpression;

    private float blinkweight = 0f;
    private float velocity = 0f;
    private bool isblink = false;

    private GameObject mic;
    private MicController miccont;
    private float mouthweight = 0f;

    // Start is called before the first frame update
    void Start()
    {
        vrm = GameObject.Find("VRM1");
        instance = vrm.GetComponent<Vrm10Instance>();
        runtimeExpression = instance.Runtime.Expression;
        StartCoroutine(Blink());

        mic = GameObject.Find("Mic");
        miccont = mic.GetComponent<MicController>();
    }

    IEnumerator Blink(){
        while(true){
            isblink = false;
            yield return new WaitForSeconds(Random.Range(3f, 9f));
            isblink = true;
            yield return new WaitForSeconds(Random.Range(0.1f,0.3f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isblink){
            blinkweight = Mathf.SmoothDamp(blinkweight, 1f, ref velocity, 0.05f);
        }else{
            blinkweight = Mathf.SmoothDamp(blinkweight, 0f, ref velocity, 0.05f);
        }

        mouthweight = miccont.GetMicVolume();

        runtimeExpression.SetWeight(ExpressionKey.Aa, mouthweight);
        runtimeExpression.SetWeight(ExpressionKey.Blink, blinkweight);
        runtimeExpression.SetWeight(ExpressionKey.Neutral, 1f);
        
    }
}
