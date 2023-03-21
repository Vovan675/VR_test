using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkDisabler : MonoBehaviour
{
    public PhotonView view;
    public List<GameObject> NetworkOnlyGO;
    public List<GameObject> LocalOnlyGO;
    public List<Behaviour> NetworkOnlyMB;
    public List<Behaviour> LocalOnlyMB;
    void Start()
    {
        
        NetworkOnlyGO.ForEach(x => x.SetActive(!view.IsMine));
        LocalOnlyGO.ForEach(x => x.SetActive(view.IsMine));
        NetworkOnlyMB.ForEach(x => x.enabled = (!view.IsMine));
        LocalOnlyMB.ForEach(x => x.enabled = (view.IsMine));
    }
}
