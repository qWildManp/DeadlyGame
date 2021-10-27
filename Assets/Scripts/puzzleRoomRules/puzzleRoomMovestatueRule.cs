using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleRoomMovestatueRule : puzzleRoomRule
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> Sets;
    private int correctNum;
    [SerializeField] List<GameObject> answerList;
    [SerializeField] bool randomAns;
    void Start()
    {
        correctNum = 0;
        isSolved =  false;
        playerEnter = false;
        if (randomAns && answerList.Count > 0)
        {
            List<GameObject> ansList = answerList;
            foreach (GameObject set in Sets)
            {
                puzzleSetRule setRule = set.GetComponent<puzzleSetRule>();
                int rndIndex = Random.Range(0, ansList.Count);
                GameObject rndAnswer = ansList[rndIndex];
                setRule.SetAnswer(rndAnswer);
                ansList.Remove(rndAnswer);
            }
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        SetDoorLock();
        correctNum = 0;
        foreach(GameObject set in Sets)
        {
            puzzleSetRule setRule = set.GetComponent<puzzleSetRule>();
            if (setRule.CheckSetCorrect() == true)
            {
                correctNum += 1;
            }

        }
        if (correctNum == Sets.Count)
            isSolved = true;
        else
            isSolved = false;
    }
}
