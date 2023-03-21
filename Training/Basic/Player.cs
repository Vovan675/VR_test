using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IPunInstantiateMagicCallback
{
    public CharacterController controller;
    public TMP_Text nicknameText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        info.Sender.TagObject = gameObject;
        //Set nickname...
        nicknameText.text = info.Sender.NickName;
    }

    // Pun RPC's...


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TeleportArea>(out var area))
        {
            controller.Move(area.GetDeltaPos());
            area.ApplyForce();
        }
    }
}
