using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class SpawnPlayerTest : NetworkBehaviour

    
{
    public GameObject myPlayer;
    public Vector3 myLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            GameObject go = Instantiate(myPlayer, myLocation, myPlayer.transform.rotation);
            go.GetComponent<NetworkObject>().Spawn();
            Debug.Log("Spawned");
        }
    }
}
