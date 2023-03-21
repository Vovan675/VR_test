using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRButton : MonoBehaviour
{
    public UnityEvent OnClick;

    public void Click()
    {
        OnClick.Invoke();
        SoundManager.instance.Play("Button");
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }


}
