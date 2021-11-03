using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
    EnemyLocomotionSystem enemyLocomotionSystem;
    EnemyAnimatorManager enemyAnimatorManager;

    public State currenState;
    public PlayerStats currentTarget;
    public NavMeshAgent navMeshAgent;
    public Rigidbody enemyRigiBody;

    public bool isPerformingAction;
    public float distanceFromTarget;
    public float rotationSpeed = 25;
    public float maxAttackRange = 60;
    public float viewableAngle;

    [Header("A.I. Settings")]
    public float maxDetectionRange;
    public float detectionRadius;
    //The higher, and lower, respetetively these angle are, the greater detection FIELD OF VIEW
    public float maxDetectionAngle = 50;
    public float minDetectionAngle = -50;
    public float currentRecoveryTime = 0;
    void Awake()
    {
        enemyLocomotionSystem = GetComponent<EnemyLocomotionSystem>();
        enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        navMeshAgent.enabled = true;
        enemyRigiBody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        enemyRigiBody.isKinematic = false;
    }
    private void Update()
    {
        HandleRecoveryTimer();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HandleStateMachine();
    }

    private void HandleStateMachine()
    {
        /*
        if(enemyLocomotionSystem.currentTarget != null)
        {
            enemyLocomotionSystem.distanceFromTarget = Vector3.Distance(enemyLocomotionSystem.currentTarget.transform.position, transform.position);
        }
        
        if(enemyLocomotionSystem.currentTarget == null)// if there is no player find player
        {
            enemyLocomotionSystem.HandleDetection();
        }
        else if(enemyLocomotionSystem.distanceFromTarget > enemyLocomotionSystem.stoppingDistance)// if find player, move to player
        {
            Debug.Log("handle move to target");
            enemyLocomotionSystem.HandleMoveToTarget();
        }
        else if(enemyLocomotionSystem.distanceFromTarget <= enemyLocomotionSystem.stoppingDistance)
        {
            //Handle our attack
            Debug.Log("handle attack");
            //AttackTarget();
        }*/

        if(currenState != null)
        {
            State nextState = currenState.Tick(this, enemyAnimatorManager);

            if(nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }
    }
    
    private void SwitchToNextState(State state)
    {
        currenState = state;
    }
    private void AttackTarget()
    {/*
        if (isPerformingAction)
            return;

        if(currentAttack == null)
        {
            GetNewAttack();
        }
        else
        {
            isPerformingAction = true;
            currentRecoveryTime = currentAttack.recoveryTime;
            enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
            enemyAnimatorManager.animator.SetFloat("Vertical", 0);
            currentAttack = null;
        }
        */
    }
    private void GetNewAttack()
    {/*
        Vector3 targetDirection = enemyLocomotionSystem.currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
        enemyLocomotionSystem.distanceFromTarget = Vector3.Distance(enemyLocomotionSystem.currentTarget.transform.position, transform.position);

        int maxScore = 0;

        for (int i = 0; i <enemyAttacks.Length; i++){
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if(enemyLocomotionSystem.distanceFromTarget <= enemyAttackAction.maxDistanceNeedToAttack
                && enemyLocomotionSystem.distanceFromTarget >= enemyAttackAction.minDistanceNeedToAttack)
            {
                if(viewableAngle<= enemyAttackAction.maxAttackAngle
                    && viewableAngle >= enemyAttackAction.minAttackAngle)
                {
                    maxScore += enemyAttackAction.attackScore;
                }
            }
        }

        int randomValue = Random.Range(0, maxScore);
        int tempScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if (enemyLocomotionSystem.distanceFromTarget <= enemyAttackAction.maxDistanceNeedToAttack
                && enemyLocomotionSystem.distanceFromTarget >= enemyAttackAction.minDistanceNeedToAttack)
            {
                if (viewableAngle <= enemyAttackAction.maxAttackAngle
                    && viewableAngle >= enemyAttackAction.minAttackAngle)
                {
                    if (currentAttack != null)
                        return;
                    tempScore += enemyAttackAction.attackScore;
                    if(tempScore > randomValue)
                    {
                        currentAttack = enemyAttackAction;
                    }
                }
            }
        } */
    }
   
    private void HandleRecoveryTimer()
    {
        if(currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }

        if (isPerformingAction)
        {
            if(currentRecoveryTime <= 0)
            {
                isPerformingAction = false;
            }
        }
    }
}
