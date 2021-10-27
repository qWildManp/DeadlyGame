using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleRoomFindMissingPartRule : puzzleRoomRule
{
    // Start is called before the first frame update
    [SerializeField] List<Transform> puzzleItemSpawnPoints;
    [SerializeField] GameObject handlePrefab;
    [SerializeField] GameObject fuseBox;
    void Start()
    {
        isSolved = false;
        playerEnter = false;
        int rnd_index = Random.Range(0, puzzleItemSpawnPoints.Count);
        Transform rnd_spawnPoint = puzzleItemSpawnPoints[rnd_index];
        GameObject handle = Instantiate(handlePrefab);
        handle.GetComponent<RoomItem>().SetSpawnAt(rnd_spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        SetDoorLock();
        if (!fuseBox.GetComponent<fuseboxBehavior>().GetOpenStatus())
        {
            isSolved = true;
        }
        if (isSolved)
        {
            Debug.Log("Puzzle solved");
        }
    }
}
