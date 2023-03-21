using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class XRDisabler : MonoBehaviour
{
    public Transform camera;
    public List<MonoBehaviour> VROnly;
    public List<MonoBehaviour> KeyboardOnly;
    
    void Start()
    {
        WebXRManager_OnXRChange(WebXRState.NORMAL, 0, Rect.zero, Rect.zero);
    }

    private void OnEnable()
    {
        WebXRManager.OnXRChange += WebXRManager_OnXRChange;   
    }

    private void OnDisable()
    {
        WebXRManager.OnXRChange -= WebXRManager_OnXRChange;   
    }

    private void WebXRManager_OnXRChange(WebXRState state, int viewsCount, Rect leftRect, Rect rightRect)
    {
        var pos = camera.transform.position;
        pos.y = 1.6f;
        camera.transform.position = pos;

        VROnly.ForEach(x => x.enabled = state == WebXRState.VR);
        KeyboardOnly.ForEach(x => x.enabled = state == WebXRState.NORMAL);
    }
}
