using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject Message;
    private Transform Messageblank;
    [SerializeField] private GameObject PlaceNameblank;
    [SerializeField]private int msgCountdown;
    private float msgCurrentCountDown;
    void Start()
    {
        msgCurrentCountDown = msgCountdown;
        Messageblank = Message.transform.Find("Msg_text");
    }

    // Update is called once per frame
    void Update()
    {
        if(GetMessage() != "")
        {
            Message.SetActive(true);
            msgCurrentCountDown -= Time.deltaTime;
            if (msgCurrentCountDown <= 0)
            {
                ClearMessage();
                Message.SetActive(false);
                msgCurrentCountDown = msgCountdown;
            }
        }
        else
        {
            msgCurrentCountDown = msgCountdown;
        }
       
    }
    public void SetPlaceName(string placename, RoomType roomtype)
    {
        Text temp = PlaceNameblank.GetComponent<Text>();
        temp.text = placename;
        switch (roomtype)
        {
            case RoomType.DANGER:
                temp.color = Color.red;
                break;
            case RoomType.PUZZLE:
                temp.color = Color.blue;
                break;
            case RoomType.FINAL_PUZZLE:
                temp.color = Color.blue;
                break;
            case RoomType.END:
                temp.color = Color.cyan;
                break;
            default:
                temp.color = Color.green;
                break;
        }
    }
    public void SetMessage(string msg)
    {
        Messageblank.GetComponent<Text>().text = msg;
    }
    public string GetMessage()
    {
        return Messageblank.GetComponent<Text>().text;
    }
    public void ClearMessage()
    {
        Messageblank.GetComponent<Text>().text = "";
    }
}
