using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject readyButton;
    public GameObject leaveButton;

    public void ReadtoPlay()
    {
        readyButton.SetActive(false);
        //leaveButton.SetActive(false);
        PhotonNetwork.Instantiate("Player", new Vector3(1, 1, 0), Quaternion.identity, 0);
    }

    public void leaveRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("µã»÷ÁËleave");
            PhotonNetwork.LeaveRoom();
        }
    }

    public override void OnLeftRoom()
    {
        //base.OnLeftRoom();
        PhotonNetwork.LoadLevel(0);
        //SceneManager.LoadScene("Start");

    }
}
