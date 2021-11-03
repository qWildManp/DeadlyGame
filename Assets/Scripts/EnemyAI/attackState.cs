using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackState : State
{
    public pursueState pursueState;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;
    public override State Tick(EnemyManager enemyManager, EnemyAnimatorManager enemyAnimatorManager)
    {
        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
        //check for attack range
        if(enemyManager.currentRecoveryTime <=0 && enemyManager.distanceFromTarget <= enemyManager.maxAttackRange)
        {
            if (enemyManager.isPerformingAction)
                return this;

            if (currentAttack != null)
            {
                GetNewAttack(enemyManager);
                if (enemyManager.distanceFromTarget < currentAttack.minDistanceNeedToAttack)
                {
                    return this;
                }
                else if (enemyManager.distanceFromTarget < currentAttack.minDistanceNeedToAttack)
                {
                    //if within range do attack
                    if (enemyManager.viewableAngle <= currentAttack.maxAttackAngle
                        && enemyManager.viewableAngle >= currentAttack.minAttackAngle)
                    {
                        if (enemyManager.currentRecoveryTime <= 0 && enemyManager.isPerformingAction == false)
                        {
                            enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                            enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
                            enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
                            currentAttack = null;
                        }
                    }
                }
            }
            else
            {
                GetNewAttack(enemyManager);
            }
            return this;
        }
        else if(enemyManager.distanceFromTarget > enemyManager.maxAttackRange)
        {
            return pursueState;
        }
        // if in attack
        return this;
    }
    private void GetNewAttack(EnemyManager enemyManager)
    {
        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);

        int maxScore = 0;

        for (int i = 0; i <enemyAttacks.Length; i++){
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if(enemyManager.distanceFromTarget <= enemyAttackAction.maxDistanceNeedToAttack
                && enemyManager.distanceFromTarget >= enemyAttackAction.minDistanceNeedToAttack)
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
            if (enemyManager.distanceFromTarget <= enemyAttackAction.maxDistanceNeedToAttack
                && enemyManager.distanceFromTarget >= enemyAttackAction.minDistanceNeedToAttack)
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
        } 
    }
}

