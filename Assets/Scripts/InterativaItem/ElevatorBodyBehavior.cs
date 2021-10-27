using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class ElevatorBodyBehavior : MonoBehaviour
{
    [SerializeField] GameObject innerButton;
    [SerializeField] GameObject elevatorDoor;
    private Animator animator;
    private Animator doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //doorAnimator = elevatorDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (innerButton.GetComponent<ElevatorButtonBehavior>().GetButtonPress())
        {
           
            animator.SetBool("open", true);
        }
        else
        {
            animator.SetBool("open", false);
        }
    }
}
