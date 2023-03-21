using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour, IPunInstantiateMagicCallback
{
    public string nickname;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        nickname = info.Sender.NickName;
        info.Sender.TagObject = gameObject;
    }
}
