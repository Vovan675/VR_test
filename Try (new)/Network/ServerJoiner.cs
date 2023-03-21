using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ServerJoiner : MonoBehaviourPunCallbacks
{
    public static string NickName = "Basic Nickname";
    public PlayerFactory factory;
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
        factory.CreatePlayer(PhotonNetwork.PlayerList.Length);
    }
}
