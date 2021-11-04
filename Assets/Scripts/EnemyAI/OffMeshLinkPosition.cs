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
        RaycastHit hitResult;
        Debug.DrawRay(transform.position, Vector3.down * 500f);
        if(Physics.Raycast(transform.position, Vector3.down, out hitResult, 500f, layerMask)){
            
            hasCheckedGroundPosition = true;
            transform.position =hitResult.point;
            transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + 0.1f, transform.localPosition.z);//adjust the navmesh connection point
        }
    }
}
