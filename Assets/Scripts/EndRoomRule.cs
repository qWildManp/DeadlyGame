using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoomRule : MonoBehaviour
{
    [SerializeField] GameObject gravityPuzzleRoom;
    [SerializeField] GameObject moveStatueRoom;
    [SerializeField] GameObject gravityPuzzleLight;
    [SerializeField] GameObject moveStatueLight;
    [SerializeField] private GameObject outterButton;
    [SerializeField] private bool gravityPuzzleSolved;
    [SerializeField] private bool moveStatueSolved;
    // Start is called before the first frame update
    void Start()
    {
        gravityPuzzleSolved = false ;
        moveStatueSolved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gravityPuzzleRoom && moveStatueRoom)
        {
            if (gravityPuzzleRoom.GetComponent<puzzleRoomGravityPuzzleRule>().GetPuzzleIsSolved())
            {
                gravityPuzzleSolved = true;
            }
            if (moveStatueRoom.GetComponent<puzzleRoomMovestatueRule>().GetPuzzleIsSolved())
            {
                moveStatueSolved = true;
            }
            if (gravityPuzzleSolved && moveStatueSolved)
            {
                outterButton.GetComponent<ElevatorButtonBehavior>().SetButtonActive();
            }
        }
        gravityPuzzleLight.transform.GetChild(1).GetComponent<EndRoomLightShining>().SetLightColor(gravityPuzzleSolved);
        moveStatueLight.transform.GetChild(1).GetComponent<EndRoomLightShining>().SetLightColor(moveStatueSolved);
    }

    public void GetTwoPuzzleRooms()
    {
        gravityPuzzleRoom = GameObject.Find("finalpuzzleroom-gavitymazz(Clone)");
        moveStatueRoom = GameObject.Find("finalpuzzleroom-movestatue(Clone)");
    }
}
