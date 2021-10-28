using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject Messageblank;
    [SerializeField]private int msgCountdown;
    private float msgCurrentCountDown;
    void Start()
    {
        msgCurrentCountDown = msgCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetMessage() != "")
        {
            msgCurrentCountDown -= Time.deltaTime;
            if (msgCurrentCountDown <= 0)
            {
                ClearMessage();
                msgCurrentCountDown = msgCountdown;
            }
        }
        else
        {
            msgCurrentCountDown = msgCountdown;
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
