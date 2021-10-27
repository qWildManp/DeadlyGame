using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
public class ItemInfoDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowInfo(GameObject itemDisplayer)
    {
        GameObject item = itemDisplayer.GetComponent<ItemDisplayer>().GetItem();
        Sprite img =  itemDisplayer.GetComponent<Image>().sprite;
        Transform target_img = transform.GetChild(1);
        Transform target_text = transform.GetChild(0);
        target_img.GetComponent<Image>().sprite = img;
        target_text.GetComponent<Text>().text ="Item Name: " + item.GetComponent<RoomItem>().GetItemName();
        Debug.Log("Click on" + item.GetComponent<RoomItem>().GetItemName());
    }
}
