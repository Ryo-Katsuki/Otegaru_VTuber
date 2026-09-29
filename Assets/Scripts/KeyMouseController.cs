using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyMouseController : MonoBehaviour, VTIAA.IKMAMActions {
    VTIAA actionasset;

    private GameObject rhtarget = null;
    private GameObject lhtarget = null;
    private float mousex = 0f;
    private float mousey = 0f;
    public float mousegain;

    void Awake(){
        actionasset = new VTIAA();
        actionasset.KMAM.SetCallbacks(this);
    }
    void OnEnable(){
        actionasset.Enable();
    }
    void OnDisable(){
        actionasset.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        rhtarget = GameObject.Find("RHTarget");
        lhtarget = GameObject.Find("LHTarget");
    }

    // Update is called once per frame
    void Update()
    {
        rhtarget.transform.position = new Vector3(mousey * mousegain + 0.1f, 1.1f, mousex * mousegain + 0.3f);
    }

    public void OnMouseX(InputAction.CallbackContext context){
        mousex = context.ReadValue<float>();
    }
    public void OnMouseY(InputAction.CallbackContext context){
        mousey = context.ReadValue<float>();
    }
}
