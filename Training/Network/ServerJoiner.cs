using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ServerJoiner : MonoBehaviourPunCallbacks
{
    public static string Name = "User";
    public PlayerFactory playerFactory;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = Name;
        playerFactory.CreatePlayer(PhotonNetwork.PlayerList.Length);

    }
}
