using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Runtime.InteropServices.WindowsRuntime;
using QFSW.QC;

public class NetworkPlayer_2 : NetworkBehaviour
{

    public GameObject playerPrefab;
    public int clientID;

    private GameObject _mplayer;

    public GameObject[] spawnPoints;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        clientID = (int)OwnerClientId;

        if (IsServer)
        {
            _mplayer = playerPrefab;
        }
    }
    [Command]
    public GameObject SpawnPlayer()
    {
        GameObject go = Instantiate(playerPrefab, spawnPoints[1].transform.position, Quaternion.identity);
        go.GetComponent<NetworkObject>().SpawnWithOwnership(OwnerClientId);
        return go;
    }
}
