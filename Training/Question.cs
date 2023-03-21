using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;

public class Question : MonoBehaviour
{
    public string QuestionText;

    [ContextMenu("test")]
    public void AddAnswer(string answer)
    {
        StartCoroutine(AddAnswerRoutine(answer));
    }

    IEnumerator AddAnswerRoutine(string answer)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", PhotonNetwork.LocalPlayer.NickName);
        form.AddField("answer", answer);
        form.AddField("question", QuestionText);
        UnityWebRequest request = UnityWebRequest.Post("https://prof-nsu.ru/answer.php", form);

        yield return request.SendWebRequest();
        if (request.isNetworkError)
        {
            print(request.error);
        }
        else
        {
            print(request.downloadHandler.text);
        }
    }
}
