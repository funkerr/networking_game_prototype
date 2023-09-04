using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkCameraScriptTest : NetworkBehaviour
{

    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            playerCamera.enabled = false;
        }
    }
}