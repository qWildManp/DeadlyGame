using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class RoomItem : InteractiveItem
{
    [SerializeField] private RoomItemType itemType;
    [SerializeField] private string itemName;
    private Transform SpawnAt;
    // Start is called before the first frame update
    void Awake()
    {
        isChecked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnAt)
        {
            transform.position = SpawnAt.transform.position;
            //transform.forward = SpawnAt.forward;
        }
        if (isChecked)
        {
            SetHightLight(true);
        }
        else
        {
            SetHightLight(false);
        }
        isChecked = false;
            
    }
    public string GetItemName()
    {
        return this.itemName;
    }
    public void SetSpawnAt(Transform spawnPoint)
    {
        this.SpawnAt = spawnPoint;
    }
}
