using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalshLightBehavior : MonoBehaviour
{
    [SerializeField]private bool open;
    [SerializeField]private int battery;
    [SerializeField]private float countDown;
    private float currentCountDown;
    [SerializeField]public bool inPlayerHand;
    // Start is called before the first frame update
    void Start()
    {
        currentCountDown = countDown;
        inPlayerHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(open && inPlayerHand)
            currentCountDown -= Time.deltaTime;
        if (currentCountDown <= 0)
        {
            Debug.Log("Battery loss");
            if (battery > 0)
            {
                battery -= 1;
            }

            currentCountDown = countDown;
        }
        if(battery <= 0)
        {
            open = false;
        }
        if (Input.GetKeyDown(KeyCode.L) && inPlayerHand)
        {
            if (battery > 0)
                open = !open;
            else
                Debug.Log("I need battery !");
        }
        if (open)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
