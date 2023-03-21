using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class WebXRDisabler : MonoBehaviour
{
    public Camera cam;

    public List<MonoBehaviour> VROnly = new List<MonoBehaviour>();
    public List<MonoBehaviour> KeyboardOnly = new List<MonoBehaviour>();
    private void Start()
    {
#if UNITY_EDITOR
        WebXRManager_OnXRChange(WebXRState.NORMAL, 0, Rect.zero, Rect.zero);
#else
        WebXRManager_OnXRChange(WebXRState.NORMAL, 0, Rect.zero, Rect.zero);
#endif
    }

    private void OnEnable()
    {
        WebXRManager.OnXRChange += WebXRManager_OnXRChange;
    }

    private void OnDisable()
    {
        WebXRManager.OnXRChange += WebXRManager_OnXRChange;
    }

    private void WebXRManager_OnXRChange(WebXRState state, int viewsCount, Rect leftRect, Rect rightRect)
    {
        Vector3 pos = cam.transform.position;
        if (state == WebXRState.VR)
        {
            pos.y = 1.6f;
        }
        else if (state == WebXRState.NORMAL)
        {
            pos.y = 1.6f;
        }

        cam.transform.position = pos;

        VROnly.ForEach(x => x.enabled = state == WebXRState.VR);
        KeyboardOnly.ForEach(x => x.enabled = state == WebXRState.NORMAL);
    }
}
