using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventary : MonoBehaviour
{
    GameObject UI;
    [SerializeField] private Dictionary<GameObject, int> Inventarys;
    [SerializeField] private GameObject playerFlashLight;
    [SerializeField] private List<GameObject> itemPrefabes;
    [SerializeField] private GameObject playerInventaryUI;
    private bool UI_status;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas");
        Inventarys = new Dictionary<GameObject, int>();
        UI_status = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInventaryUI.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void AddItem(GameObject item)
    {
        RoomItem itemProperty = item.GetComponent<RoomItem>();
        foreach(GameObject prefabe in itemPrefabes)
        {

            if (prefabe.GetComponent<RoomItem>().GetItemName() == itemProperty.GetItemName())
            {
                if (Inventarys.ContainsKey(prefabe))
                {
                    Inventarys[prefabe] += 1;
                }
                else
                {
                    if(item.GetComponent<RoomItem>().GetItemType() == RoomItemType.CLUE)//if picked item is clue then transfer the clue message
                    {
                        prefabe.GetComponent<RoomItem>().SetItemDescribtion(item.GetComponent<RoomItem>().GetItemDescribtion());
                    }
                    if(item.GetComponent<RoomItem>().GetItemType() == RoomItemType.KEY)
                    {
                        UI.GetComponent<MsgDisplayer>().ClearSecondObjective();
                    }
                    Inventarys.Add(prefabe, 1);
                }
                break;
            }
        }
      
    }
    public void UseBattery(GameObject item)//Use battery
    {
        FlashLightBehavior flashLight = playerFlashLight.GetComponent<FlashLightBehavior>();
        if (!Inventarys.ContainsKey(item))
            return;
        if (Inventarys[item] <= 0)// if there is no avaliable battery 
        {
            UI.GetComponent<MsgDisplayer>().SetMessage("No Battery!");
            return;
        }
        if (playerFlashLight.activeInHierarchy)
        {
            if (flashLight.AddBattery())
                Inventarys[item] -= 1;
        }
        else // if player haven't found flashlight
        {
            UI.GetComponent<MsgDisplayer>().SetMessage("I need a flashlight!");
        }

    }
    public KeyValuePair<GameObject,int> GetItem(GameObject item)// Return the item and its num
    {
        RoomItem itemProperty = item.GetComponent<RoomItem>();
        foreach (KeyValuePair<GameObject, int> inventaryItem in Inventarys)
        {
            if(inventaryItem.Key.GetComponent<RoomItem>().GetItemName() == itemProperty.GetItemName())
            {
                return inventaryItem;
            }
        }
        KeyValuePair<GameObject, int> emptyPair = new KeyValuePair<GameObject, int>();

        return emptyPair;
    }
    public void ChangePlayerInventaryDisplay()//show player inventary
    {
        UI_status = !UI_status;
        playerInventaryUI.SetActive(UI_status);
        /*
        string showStr = "Items \n";
        int i = 0;
        foreach(KeyValuePair<GameObject,int> item in Inventarys)
        {
            showStr += ++i + "[" + item.Key + "], Num: " + item.Value + "\n"; 
        }
        Debug.Log(showStr);*/
    }
    public Dictionary<GameObject, int> GetInventaryList()//return inventary list
    {
        return this.Inventarys;
    }
    public bool FindItem(string requirement)// Check if player has found this item
    {
        foreach (KeyValuePair<GameObject, int> item in Inventarys)
        {
            RoomItem itemInfo = item.Key.GetComponent<RoomItem>();
            string itemName = itemInfo.GetItemName();
            if (itemName == requirement)
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckItem(string requirement)// Check the Number of this item
    {
        if(Inventarys.Count == 0)
        {
            return false;
        }
        foreach(KeyValuePair<GameObject,int> item in Inventarys)
        {
            RoomItem itemInfo = item.Key.GetComponent<RoomItem>();
            string itemName = itemInfo.GetItemName();
            if(itemName == requirement && item.Value > 0)
            {
                return true;
            }
        }
        return false;
    }
    public bool UseItem(string requirement)
    {
        foreach (KeyValuePair<GameObject, int> item in Inventarys)
        {
            RoomItem itemInfo = item.Key.GetComponent<RoomItem>();
            string itemName = itemInfo.GetItemName();
            if (itemName == requirement && item.Value > 0)
            {
                Inventarys[item.Key] -= 1;
                return true;
            }
        }
        return false;
    }
}
