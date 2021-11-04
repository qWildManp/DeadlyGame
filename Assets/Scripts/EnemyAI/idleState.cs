using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class idleState : State
{
    public pursueState pursueState;
    public LayerMask detectionLayer;
    public Vector3 targetPos;
    public override State Tick(EnemyManager enemyManager, EnemyAnimatorManager enemyAnimatorManager)
    {

        if (!enemyManager.navMeshAgent.pathPending)//�ж����ڼ����·��
        {
            Debug.Log("test");
            if (enemyManager.navMeshAgent.remainingDistance <= enemyManager.navMeshAgent.stoppingDistance)//�Ƿ���·����
            {
                Debug.Log("test2");
                if (!enemyManager.navMeshAgent.hasPath || enemyManager.navMeshAgent.velocity.sqrMagnitude == 0f)//�Ƿ񵽴�Ŀ�ĵأ������ͣ��
                {
                    Vector3 randomDirection = enemyManager.transform.position + Random.insideUnitSphere * 600;
                    NavMeshHit destionation;
                    bool hasDestination = NavMesh.SamplePosition(randomDirection, out destionation, 600,NavMesh.AllAreas);
                    if (hasDestination)
                        targetPos = destionation.position;

                }
            }
        }
        SetRoutine(enemyManager, targetPos);
        enemyManager.navMeshAgent.nextPosition = transform.position;
        // handle player detection
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);
        foreach (var collider in colliders)
        {
            if (collider.tag == "Player")
            {
                Vector3 playerPos = collider.transform.position;
                Vector4 targetDirection = playerPos - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
                if (viewableAngle > enemyManager.minDetectionAngle && viewableAngle < enemyManager.maxDetectionAngle)
                {
                    enemyManager.currentTarget = collider.GetComponentInParent<PlayerStats>();
                }

            }
        }

        if (enemyManager.navMeshAgent.remainingDistance > enemyManager.navMeshAgent.stoppingDistance)
        {
            enemyAnimatorManager.animator.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
        }
        else
        {
            enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
        }
        //Handle Switch to next state
        if (enemyManager.currentTarget != null)
        {
            return pursueState;
        }
        else
        {
            return this;
        }
    }

    private void SetRoutine(EnemyManager enemyManager,Vector3 pos)
    {
            enemyManager.navMeshAgent.enabled = true; //activate navmesh agent
            enemyManager.navMeshAgent.SetDestination(pos);//�ߵ������֮����Ҫ��������һ����·��
            enemyManager.enemyRigiBody.velocity = enemyManager.navMeshAgent.desiredVelocity;
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, enemyManager.navMeshAgent.transform.rotation, enemyManager.rotationSpeed / Time.deltaTime);  
    }
   
}
