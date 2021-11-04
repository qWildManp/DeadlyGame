using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerRoomBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject killer;
    private bool canGenerateKiller;
    private int roomInSublevel;
    [SerializeField] private int playerInLevel;
    void Start()
    {
        canGenerateKiller = true;
        roomInSublevel = System.Convert.ToInt32(GetComponent<Room>().getRoomID()[0]);
    }

    // Update is called once per frame
    void Update()
    {
        //handle two danger room connected each other
        Room roomInfo = GetComponent<Room>();
        Dictionary<Transform, GameObject> exitConnectingTo = roomInfo.getExitConnectingTo();
        foreach (KeyValuePair<Transform, GameObject> exit in exitConnectingTo)
         {
                GameObject connectingRoom = exit.Value;
            if (connectingRoom == null)
                continue;
            Room connectingRoomBehavior = exit.Value.GetComponent<Room>();
            if (connectingRoomBehavior.GetRoomType() == RoomType.DANGER)//if this room connect to another danger room, connecting danger room will not activate killer
            {
                 connectingRoom.GetComponent<DangerRoomBehavior>().setRoomCanGenerateKiller(false);
            }
        }
        //handle killer activate
        int playerCurrentLevel = GameObject.Find("LevelManager").GetComponent<LevelManager>().GetPlayerInLevel();
        this.playerInLevel = playerCurrentLevel;
        if(playerInLevel == roomInSublevel && canGenerateKiller)
        {

            //TODO: killer activate successfully but it shows warning: Failed to create agent because it is not close enough to the NavMesh.And killer cannot move on the Navmesh
            killer.SetActive(true);
            killer.transform.SetParent(null, true);
        }
        if (!canGenerateKiller || playerInLevel != roomInSublevel)
        {
            killer.SetActive(false);
        }
    }

    private void setRoomCanGenerateKiller(bool result)
    {
        this.canGenerateKiller = result;
    }
}
