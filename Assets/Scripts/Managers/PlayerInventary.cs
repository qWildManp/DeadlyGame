using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventary : MonoBehaviour
{
    [SerializeField] private Dictionary<GameObject, int> Inventarys;
    [SerializeField] private GameObject testItemprefabe;
    [SerializeField] private List<GameObject> itemPrefabes;
    [SerializeField] private GameObject playerInventaryUI;
    private bool UI_status;
    // Start is called before the first frame update
    void Start()
    {
        Inventarys = new Dictionary<GameObject, int>();
        if (testItemprefabe)
        {
            GameObject testItem = Instantiate(testItemprefabe);
            AddItem(testItem);
        }
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
                Debug.Log("Find item ,addd");
                if (Inventarys.ContainsKey(prefabe))
                {
                    Inventarys[prefabe] += 1;
                }
                else
                {
                    Inventarys.Add(prefabe, 1);
                }
                break;
            }
        }
      
    }
    public void ChangePlayerInventaryDisplay()
    {
        UI_status = !UI_status;
        playerInventaryUI.SetActive(UI_status);
        string showStr = "Items \n";
        int i = 0;
        foreach(KeyValuePair<GameObject,int> item in Inventarys)
        {
            showStr += ++i + "[" + item.Key + "], Num: " + item.Value + "\n"; 
        }
        Debug.Log(showStr);
    }
    public Dictionary<GameObject, int> GetInventaryList()
    {
        return this.Inventarys;
    }
    public bool CheckItem(string requirement)
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
}
