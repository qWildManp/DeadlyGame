using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToObject : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
