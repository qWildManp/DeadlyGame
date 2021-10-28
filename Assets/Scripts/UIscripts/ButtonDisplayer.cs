using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Info_UI;
    [SerializeField] GameObject requireItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Info_UI.GetComponent<ItemInfoDisplayer>().currentDisplayItem == requireItem)
        {
            //this.gameObject.SetActive(true);
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            //this.gameObject.SetActive(false);
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
