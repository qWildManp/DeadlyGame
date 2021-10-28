using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonBehavior : InteractiveItem
{
    // Start is called before the first frame update
    private bool isPressed;
    [SerializeField] private bool activated; 
    void Start()
    {
        itemAnimator = GetComponent<Animator>();
        isChecked = false;
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChecked && !itemAnimator.GetBool("open"))
        {
            SetHightLight(true);
        }
        else
        {
            SetHightLight(false);
        }
        isChecked = false;
        player = GameObject.Find("Player");
        if (player)
        {
            playerCapsule = player.transform.GetChild(2);
            playerCamera = player.transform.GetChild(0);
            Ray ray = player.GetComponent<PlayerRayCast>().GetPlayerRay();
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 120))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isChecked = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (activated)
                            PressButton();
                        else
                            Debug.Log("Doesn't work... There might be something to activate it..");
                    }
                }

            }
        }
    }
    public void SetButtonActive()
    {
        activated = true;
    }
    private void PressButton()
    {
        itemAnimator.SetBool("open", true);
        isPressed = true;
    }
    public bool GetButtonPress()
    {
        return this.isPressed;
    }
}
