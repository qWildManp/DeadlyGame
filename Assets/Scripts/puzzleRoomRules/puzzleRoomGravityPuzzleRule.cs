using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleRoomGravityPuzzleRule : puzzleRoomRule
{
    [SerializeField] GameObject gravityPuzzle;
    GravityPuzzleBehavior puzzleBehavior;
    private void Start()
    {
        puzzleBehavior = gravityPuzzle.GetComponent<GravityPuzzleBehavior>();
    }
    private void Update()
    {
        if (puzzleBehavior.GetSolved())
            isSolved = true;
    }
}
