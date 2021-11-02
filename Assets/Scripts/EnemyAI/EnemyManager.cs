using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyLocomotionSystem enemyLocomotionSystem;
    public bool isPerformingAction;
    public float detectionRadius;

    //The higher, and lower, respetetively these angle are, the greater detection FIELD OF VIEW
    public float maxDetectionAngle = 50;
    public float minDetectionAngle = -50;
    void Awake()
    {
        enemyLocomotionSystem = GetComponent<EnemyLocomotionSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleCurrentAction();
    }

    private void HandleCurrentAction()
    {
        if(enemyLocomotionSystem.currentTarget == null)// if there is no player find player
        {
            enemyLocomotionSystem.HandleDetection();
        }
        else // if find player, move to player
        {
            enemyLocomotionSystem.HandleMoveToTarget();
        }
    }

}
