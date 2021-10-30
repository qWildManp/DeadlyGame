using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class puzzleRoomRule : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected bool isSolved;
    [SerializeField] protected bool playerEnter;
    GameObject Door1;
    GameObject Door2;
    protected void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            playerEnter = true;

    }
    public bool GetPuzzleIsSolved() {
        return this.isSolved;
    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            playerEnter = false;
    }
    protected void SetDoorLock()
    {
        Transform exit1 = GetComponent<Room>().GetParentExit();
        Transform exit2 = null;
        if (GetComponent<Room>().GetRoomType() != RoomType.FINAL_PUZZLE)
            exit2 = GetComponent<Room>().getExitConnectingTo().First().Key;
        if (exit1 && exit2)
        {
            Door1 = exit1.GetComponent<RoomGenerator>().GetDoorObject();
            Door2 = exit2.GetComponent<RoomGenerator>().GetDoorObject();
            if (Door1 && Door2)
            {
                if (playerEnter && !isSolved)
                {
                    Door1.GetComponent<DoorBehavior>().SetDoorLock(true, "SOLVE THE PUZZLE");
                    Door2.GetComponent<DoorBehavior>().SetDoorLock(true, "SOLVE THE PUZZLE");
                }
                else
                {
                    Door1.GetComponent<DoorBehavior>().SetDoorLock(false, "");
                    Door2.GetComponent<DoorBehavior>().SetDoorLock(false, "");
                }
            }
           
        }
        
    }
}
