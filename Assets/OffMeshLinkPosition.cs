using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMeshLinkPosition : MonoBehaviour
{
    // Start is called before the first frame update
    private bool hasCheckedGroundPosition;
    void Start()
    {
        
    }

    void Update(){
        if(!hasCheckedGroundPosition){
            //hasCheckedGroundPosition = true;
            TestHit();
        }
    }

    // Update is called once per frame
    void TestHit()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Ground");
        Debug.Log("Mask:" + layerMask);
        //layerMask = ~layerMask;
        RaycastHit hitResult;
        Debug.DrawRay(transform.position, Vector3.down * 500f);
        if(Physics.Raycast(transform.position, Vector3.down, out hitResult, 500f, layerMask)){
            
            //Debug.Log(hitResult.collider.gameObject.name);
            hasCheckedGroundPosition = true;
            transform.position = hitResult.point;
        }
        else{
            Debug.Log("Nothing hit");
        }
        
    }
}
