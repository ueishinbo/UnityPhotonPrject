using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class move : MonoBehaviourPun
{
    public Text nameText;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            nameText.text = PhotonNetwork.NickName;
        }
        else
        {
            nameText.text = photonView.Owner.NickName;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        if (Input.GetKey(KeyCode.W))
        {
           
            transform.Translate(Vector3.forward * Time.deltaTime * -20);
        }
        if (Input.GetKey(KeyCode.S))
        {
           
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.A))
        {
           
            transform.Translate(Vector3.left * Time.deltaTime * -20);
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            transform.Translate(Vector3.left * Time.deltaTime * 20);
        }
    }
}
