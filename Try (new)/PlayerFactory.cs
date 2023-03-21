using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    public List<Transform> points;

    public GameObject CreatePlayer(int index)
    {
        var point = points[points.Count % index];
        var player = PhotonNetwork.Instantiate("Player", point.position, point.rotation);
        PhotonNetwork.LocalPlayer.NickName = ServerJoiner.NickName;
        PhotonNetwork.LocalPlayer.TagObject = player;
        return player;
    }
}
