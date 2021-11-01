using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerCamera;
    Ray ray;
    void Start()
    {
        playerCamera = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(playerCamera.position, playerCamera.position + playerCamera.forward * 120, Color.red);
        ray = new Ray(playerCamera.position, playerCamera.forward * 120);
    }
    public Ray GetPlayerRay()
    {
        return this.ray;
    }
}
