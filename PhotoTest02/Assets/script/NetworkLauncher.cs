using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject loginUI;
    public GameObject nameUI;
    public InputField roomName;
    public InputField playerName;
    public GameObject roomListUI;

    private void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            nameUI.SetActive(true);
        }
        else
        {
            loginUI.SetActive(true);
            roomListUI.SetActive(true);
        }
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        /*if(PhotonNetwork.NickName != null)
        {
            nameUI.SetActive(false);
            loginUI.SetActive(true);
        }*/
        //base.OnConnectedToMaster();
        //nameUI.SetActive(true);
        Debug.Log("connected to the Master");
        PhotonNetwork.JoinLobby();
    }

    public void PlayButton()
    {
        nameUI.SetActive(false);
        PhotonNetwork.NickName = playerName.text;
        loginUI.SetActive(true);
        if (PhotonNetwork.InLobby)
        {
            roomListUI.SetActive(true);
        }

       

    }

    public void JoinOrCreateButton()
    {
        if (roomName.text.Length < 2)
            return;
        loginUI.SetActive(false);
        RoomOptions options = new RoomOptions { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        PhotonNetwork.LoadLevel(1);
    }
}
