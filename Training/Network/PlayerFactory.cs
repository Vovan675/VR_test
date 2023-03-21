using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    /// <summary>
    /// Factory Methdod
    /// </summary>
    /// <returns></returns>
    public GameObject CreatePlayer(int positionIndex)
    {
        var pos = positions[positionIndex % positions.Count];
        GameObject player = PhotonNetwork.Instantiate("Player", pos.position, pos.rotation);
        PhotonNetwork.LocalPlayer.NickName = ServerJoiner.Name;
        // Only local player instantiate using PhotonNetwork!
        PhotonNetwork.LocalPlayer.TagObject = player;
        return player;
    }
}
