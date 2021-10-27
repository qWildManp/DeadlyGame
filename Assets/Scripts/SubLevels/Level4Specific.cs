using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Specific : MonoBehaviour
{
    public static GameObject finalPuzzlePrefab;
    public static GameObject finalPuzzlePrefab2;

    public GameObject p1;
    public GameObject p2;

    private void Start()
    {
        finalPuzzlePrefab = p1;
        finalPuzzlePrefab2 = p2;
    }
    public static void OnRoomsGenerated()
    {
        Room room = GameObject.Instantiate(finalPuzzlePrefab).GetComponent<Room>();
        Transform connectingExitTransform = room.GetRandomExit();
        Transform currentExitTransform = RoomManager.Instance.getRandomexitfromExitPool();

        room.PositionToExit(currentExitTransform, connectingExitTransform);
        RoomManager.Instance.removeUsedExit(currentExitTransform);

        room = GameObject.Instantiate(finalPuzzlePrefab2).GetComponent<Room>();
        connectingExitTransform = room.GetRandomExit();
        currentExitTransform = RoomManager.Instance.getRandomexitfromExitPool();

        room.PositionToExit(currentExitTransform, connectingExitTransform);
        RoomManager.Instance.removeUsedExit(currentExitTransform);
        Debug.Log("Generated Final Puzzle rooms");
    }
}
