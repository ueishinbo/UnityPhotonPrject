using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomListManager : MonoBehaviourPunCallbacks
{
    public GameObject roomNamePrefab;
    public Transform gridLayout;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for(int i = 0; i < gridLayout.childCount; i++)
        {
            if (gridLayout.GetChild(i).gameObject.GetComponentInChildren<Text>().text == roomList[i].Name)
            {
                Debug.Log("Ö´ÐÐÁËÉ¾³ý");
                Destroy(gridLayout.GetChild(i).gameObject);
            }
            if(roomList[i].PlayerCount == 0)
            {
                roomList.Remove(roomList[0]);
            }
        }
        foreach(var room in roomList)
        {
            GameObject newRoom = Instantiate(roomNamePrefab, gridLayout.position,Quaternion.identity);

            newRoom.GetComponentInChildren<Text>().text = room.Name;

            newRoom.transform.SetParent(gridLayout);
        }
    }
}
