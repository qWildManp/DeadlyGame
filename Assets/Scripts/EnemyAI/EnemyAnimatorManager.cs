using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : MonoBehaviour
{
    public Animator animator;
    EnemyLocomotionSystem enemyLocomotionSystem;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyLocomotionSystem = GetComponentInParent<EnemyLocomotionSystem>();
    }
    public void TargetAnimation(string targetAnim, bool isInteracting)
    {
        animator.applyRootMotion = isInteracting;
        animator.SetBool("IsInteracting", isInteracting);
        animator.CrossFade(targetAnim, 0.2f);
    }

    private void OnAnimatorMove()// can the velocity of killer speed
    {
        float delta = Time.deltaTime;
        enemyLocomotionSystem.enemyRigiBody.drag = 0;
        Vector3 deltaPos = animator.deltaPosition;
        deltaPos.y = 0;
        Vector3 velocity = deltaPos / delta;
        enemyLocomotionSystem.enemyRigiBody.velocity = velocity;

    }

}
