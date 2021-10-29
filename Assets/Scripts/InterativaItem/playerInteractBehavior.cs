using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractBehavior : MonoBehaviour
{
    private PlayerInventary inventary;
    private Transform flashLight;
    // Start is called before the first frame update
    void Start()
    {
        inventary = GameObject.Find("PlayerInventary").GetComponent<PlayerInventary>();
        flashLight = transform.GetChild(2).GetChild(0).GetChild(0);
        flashLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = GetComponent<PlayerRayCast>().GetPlayerRay();
        RaycastHit hit;
        if (inventary.CheckItem("FLASH LIGHT"))// if player has flash light,activate the flash light 
        {
            flashLight.gameObject.SetActive(true);
            flashLight.gameObject.GetComponent<FlashLightBehavior>().inPlayerHand = true;
        }
        if (Input.GetKeyDown(KeyCode.B))//Show player Inventary
        {
            inventary.ChangePlayerInventaryDisplay();
        }
        //if(Input.GetKeyDown(KeyCode.P))//Show player Progess
        if (Physics.Raycast(ray,out hit, 200))//player pick item
        {
            GameObject obj = hit.collider.gameObject;
            RoomItem item = obj.GetComponent<RoomItem>();
            if (item)
            {
                item.SetChecked(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventary.AddItem(obj);
                    Destroy(obj);
                }
            }
        }
    }
}
