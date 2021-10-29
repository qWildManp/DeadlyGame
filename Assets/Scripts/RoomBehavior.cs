using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavior : MonoBehaviour
{
    GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            string roomName = GetComponent<Room>().GetRoomName();
            RoomType roomType = GetComponent<Room>().GetRoomType();
            UI.GetComponent<MsgDisplayer>().SetPlaceName(roomName, roomType);
        }
    }
    
}
