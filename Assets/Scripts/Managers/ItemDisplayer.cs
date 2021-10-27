using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayer : MonoBehaviour
{
    [SerializeField] GameObject itemPrefabe;
    [SerializeField] GameObject inventary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemPrefabe)
        {
            string item_name = itemPrefabe.GetComponent<RoomItem>().GetItemName();
            bool playerHasItem = inventary.GetComponent<PlayerInventary>().CheckItem(item_name);
            transform.GetChild(0).gameObject.SetActive(!playerHasItem);
        }
       
    }
    public GameObject GetItem()
    {
        return this.itemPrefabe;
    }
}
