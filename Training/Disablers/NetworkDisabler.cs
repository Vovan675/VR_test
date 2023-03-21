using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using WebXR;

public class NetworkDisabler : MonoBehaviour
{
    public PhotonView view;

    public List<MonoBehaviour> LocalOnly = new List<MonoBehaviour>();
    public List<MonoBehaviour> RemoteOnly = new List<MonoBehaviour>();

    public List<GameObject> LocalOnlyGameObjects = new List<GameObject>();
    public List<GameObject> RemoteOnlyGameObjects = new List<GameObject>();
    private void Start()
    {
        LocalOnly.ForEach(x => x.enabled = view.IsMine);
        LocalOnlyGameObjects.ForEach(x => x.SetActive(view.IsMine));
        RemoteOnly.ForEach(x => x.enabled = !view.IsMine);
        RemoteOnlyGameObjects.ForEach(x => x.SetActive(!view.IsMine));
    }

}
