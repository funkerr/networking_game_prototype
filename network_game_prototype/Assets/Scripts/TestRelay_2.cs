using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using QFSW.QC;

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
