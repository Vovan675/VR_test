using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;

class AddAnswer : MonoBehaviour
{

    public void Submit()
    {
        StartCoroutine(SubmitRoutine());
    }

    IEnumerator SubmitRoutine()
    {
        var nickname = PhotonNetwork.LocalPlayer.NickName;
        var form = new WWWForm();
        form.AddField("nickname", nickname);
        form.AddField("question", "Question test");
        form.AddField("answer", "Answer test");
        var request = UnityWebRequest.Post("https://prof-nsu.ru/addAnswer.php", form);

        yield return request.SendWebRequest();
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
    }
}
