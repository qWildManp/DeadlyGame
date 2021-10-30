using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToObject : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float linkSpeed;
    private bool isLinking;
    private float originalSpeed;
    
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originalSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate(){
        if(agent.isOnOffMeshLink && !isLinking){
            isLinking = true;
            agent.speed = linkSpeed;
        }
        else if(agent.isOnNavMesh && isLinking)
        {
            isLinking = false;
            agent.velocity = Vector3.zero;
            agent.speed = originalSpeed;
        }
    }

    public void MoveToTarget(){
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;
        /*
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(target.transform.position, path);
        if(path.status == NavMeshPathStatus.PathComplete || path.status == NavMeshPathStatus.PathPartial){
            Debug.Log("Path Found!");
            agent.SetPath(path);
        }
        else{
            Debug.Log("Path Not Found!");
        }
        //agent.Move()*/
    }
}
