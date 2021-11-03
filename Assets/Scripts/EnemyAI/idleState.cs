using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class idleState : State
{
    public pursueState pursueState;
    public LayerMask detectionLayer;

    public override State Tick(EnemyManager enemyManager, EnemyAnimatorManager enemyAnimatorManager)
    {
        // handle player detection
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);
        foreach (var collider in colliders)
        {
            if (collider.tag == "Player")
            {
                Vector3 playerPos = collider.transform.position;
                Vector4 targetDirection = playerPos - transform.position;
                Debug.Log(targetDirection);
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
                Debug.Log("angle" + viewableAngle);
                if (viewableAngle > enemyManager.minDetectionAngle && viewableAngle < enemyManager.maxDetectionAngle)
                {
                    enemyManager.currentTarget = collider.GetComponentInParent<PlayerStats>();
                }

            }
        }
        /*
        if (enemyManager.navMeshAgent.remainingDistance > enemyManager.navMeshAgent.stoppingDistance)
        {
            enemyAnimatorManager.animator.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
        }
        else
        {
            enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
        }
            if (!enemyManager.navMeshAgent.pathPending)//�ж����ڼ����·��
        {
            if (enemyManager.navMeshAgent.remainingDistance <= enemyManager.navMeshAgent.stoppingDistance)//�Ƿ���·����
            {
                if (!enemyManager.navMeshAgent.hasPath || enemyManager.navMeshAgent.velocity.sqrMagnitude == 0f)//�Ƿ񵽴�Ŀ�ĵأ������ͣ��
                {
                    SetRandomRoutine(enemyManager);
                    enemyManager.navMeshAgent.nextPosition = transform.position;
                }
            }
        } */
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

    private void SetRandomRoutine(EnemyManager enemyManager)
    {
        Vector3 newDest = Random.insideUnitSphere * 500f + new Vector3(139f, 86f, 172f);//�뾶Ϊ500�����������
        NavMeshHit destination;
        bool hasDestination = NavMesh.SamplePosition(newDest, out destination, 100f, 1);//unity��ָ������ӽ���λ��
        if (hasDestination)
        {
            enemyManager.navMeshAgent.enabled = true; //activate navmesh agent
            enemyManager.navMeshAgent.SetDestination(destination.position);//�ߵ������֮����Ҫ��������һ����·��
            enemyManager.enemyRigiBody.velocity = enemyManager.navMeshAgent.desiredVelocity;
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, enemyManager.navMeshAgent.transform.rotation, enemyManager.rotationSpeed / Time.deltaTime);
        }
        
    }

}
