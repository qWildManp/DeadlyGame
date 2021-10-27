using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private bool openable;
    private GameObject player;
    private bool playerEnter;
    [SerializeField] private bool islocked;
    [SerializeField] private string unlockRequirement;
    private bool previousPlayerOpen;
    [SerializeField] private float countDown;
    private float currentCountDown;
    // Start is called before the first frame update
    void Awake()
    {
        openable = true;
        currentCountDown = countDown;
        animator = GetComponent<Animator>();
        playerEnter = false;
    }
    private void Update()
    {
        if (openable)
        {
            if (playerEnter && Input.GetKeyDown(KeyCode.E))
            {
                if (islocked && GameObject.Find("PlayerInventary").GetComponent<PlayerInventary>().CheckItem(this.unlockRequirement))
                {// if the door is locked by key
                    Debug.Log("Door Unlocked");
                    UnlockDoor();
                }
                if (!islocked)
                {
                    //Debug.Log("Door Status:" + animator.GetBool("DoorOpen"));
                    ChangeDoorStatus();
                    if (animator.GetBool("DoorOpen"))// if door is open now mean player has open the door
                    {
                        previousPlayerOpen = true;
                        currentCountDown = countDown;
                    }
                    else // player actually close the door
                    {
                        previousPlayerOpen = false;
                    }
                }
                else
                {

                    Debug.Log("The door is locked, I need " + unlockRequirement);
                }
            }
            else
            {
                if (previousPlayerOpen == true && animator.GetBool("DoorOpen"))//if player has open this door before.
                {
                    currentCountDown -= Time.deltaTime;
                    if (currentCountDown <= 0)
                    {
                        if (animator.GetBool("DoorOpen"))// if the door is currently open
                        {
                            animator.SetBool("DoorOpen", false);
                        }
                        currentCountDown = countDown;
                        previousPlayerOpen = false;
                    }
                }

            }
        }
        else
        {
            if (playerEnter && Input.GetKeyDown(KeyCode.E))
                Debug.Log("I cannot open it!");
        }
        
    }
    public void SetDoorOpenable(bool result)
    {
        this.openable = result;
    }
    public void SetDoorLock(bool result,string requirement)
    {
        if (this.openable)
        {
            this.islocked = result;
            this.unlockRequirement = requirement;
            if(islocked)
                animator.SetBool("DoorOpen", false);
        }
    }
    public void UnlockDoor()
    {
        this.islocked = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            this.player = other.transform.parent.gameObject;
            playerEnter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.player = null;
            playerEnter = false;
        }
    }
    public void ChangeDoorStatus()
    {
        animator.SetBool("DoorOpen", !animator.GetBool("DoorOpen"));
    }
    // Update is called once per frame
}
