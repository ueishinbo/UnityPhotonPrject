using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public InputField nameInputField;//���������


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//��ʼ�����ã����ӷ�����
        Debug.Log("��ʼ���ӷ�����");
    }

    public void ButtonSS()
    {
        //Debug.Log(nameInputField.text);
        PhotonNetwork.NickName = nameInputField.text;//������������ϴ�������
        if (PhotonNetwork.InLobby)//�ж��Ƿ��ڴ����ڣ��ھ���ת��lobby����
        {
            Debug.Log("�Ѿ��ڴ�����");
            photonView.RPC("LoadGameScene", RpcTarget.All);
        }
    }

    [PunRPC]
    void LoadGameScene()
    {
        PhotonNetwork.LoadLevel(1);
    }
    //----------�ص�����-------------
    public override void OnConnectedToMaster()
    {
        Debug.Log("Pun Basics Tutorial/Launcher: OnConnectedToMaster() was by Pun");
        Debug.Log("----���ӳɹ�");
        PhotonNetwork.JoinLobby();//�������
        Debug.Log("��������С�����");
        // base.OnConnectedToMaster(); 
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("Pun Basics Tutorial/Launcher: OnConnectedToMaster() was by Pun with reason {0}", cause);
        Debug.Log("����ʧ��");
        //base.OnDisconnected(cause);
    }


}
