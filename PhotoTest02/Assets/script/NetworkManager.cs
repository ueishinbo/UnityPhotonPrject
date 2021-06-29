using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public InputField nameInputField;//名字输入框


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//初始化设置，连接服务器
        Debug.Log("开始连接服务器");
    }

    public void ButtonSS()
    {
        //Debug.Log(nameInputField.text);
        PhotonNetwork.NickName = nameInputField.text;//将输入的名字上传至网络
        if (PhotonNetwork.InLobby)//判断是否在大厅内，在就跳转到lobby界面
        {
            Debug.Log("已经在大厅中");
            photonView.RPC("LoadGameScene", RpcTarget.All);
        }
    }

    [PunRPC]
    void LoadGameScene()
    {
        PhotonNetwork.LoadLevel(1);
    }
    //----------回调函数-------------
    public override void OnConnectedToMaster()
    {
        Debug.Log("Pun Basics Tutorial/Launcher: OnConnectedToMaster() was by Pun");
        Debug.Log("----连接成功");
        PhotonNetwork.JoinLobby();//加入大厅
        Debug.Log("加入大厅中。。。");
        // base.OnConnectedToMaster(); 
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("Pun Basics Tutorial/Launcher: OnConnectedToMaster() was by Pun with reason {0}", cause);
        Debug.Log("连接失败");
        //base.OnDisconnected(cause);
    }


}
