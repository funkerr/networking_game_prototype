using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using QFSW.QC;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;

public class TestRelay_2 : MonoBehaviour
{
    // Start is called before the first frame update
    private async void Start()
    {
       await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in as " + AuthenticationService.Instance.PlayerId);
        };
    }
    [Command]
    private async void CreateRelay()
    {
        try 
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(5);
            string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            Debug.Log(joinCode);

            //Create Relay using relay transport on network manager
            //Starts Host
            RelayServerData relayServerData = new RelayServerData(allocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
            NetworkManager.Singleton.StartHost();
        }
        catch(RelayServiceException e)
        {
            Debug.LogException(e);
        }
    }
    [Command]
    private async void JoinRelay(string joinCode)
    {
        
        try {
            Debug.Log("Joined hosted relay with " + joinCode);

            JoinAllocation joinAllocation =  await RelayService.Instance.JoinAllocationAsync(joinCode);

            //Join Relay using relay transport on network manager
            //Starts Client
            RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
            NetworkManager.Singleton.StartClient();
        
        }
        catch(RelayServiceException e)
        {
            Debug.LogException(e);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
