using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavior : MonoBehaviour
{
    private Room room;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateItem(RoomItemType itemType)
    {
        //ItemManager.Instance.SpawnItemAt(itemType, )
        Transform[] availableSpawnPoints = room.GetItemSpawnPoints();
        Transform spawnPoint = GetRandomItemSpawnpoint(availableSpawnPoints);
        ItemManager.Instance.SpawnItemAt(itemType, spawnPoint);
    }
        
    
    Transform GetRandomItemSpawnpoint(Transform[] spawnPoints)
    {
        int rndIndex = Random.Range(0, spawnPoints.Length); 
        return spawnPoints[rndIndex];
    }

    void CheckForAttachedRooms()
    {
        if(room == null)
        {
            room = GetComponent<Room>();
        }
    }
}
