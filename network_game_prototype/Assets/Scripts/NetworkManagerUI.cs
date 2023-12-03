using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Services.Relay.Models;
using Unity.Networking.Transport.Relay;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
{

    public Button serverButton;
    public Button hostButton;
    public Button clientButton;
    public Button createLobbyButton;

    //public string RelayServerCode;
    
    public TestRelay_2 myRelayScript;
    public TestLobby_2 myLobbyScript;

    private void Awake()
    {
        

        serverButton.onClick.AddListener(() =>
            {
                //NetworkManager.Singleton.StartServer();
                //Testing Create Relay with button
                myRelayScript.Start();
                myRelayScript.CreateRelay();
                
                //RelayServerCode = myRelayScript.lobbyString;

                //Debug.Log("Got here");

                //Debug.Log(RelayServerCode + " is the Relay Server Code.");

                
            }
            );

        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        }
            );

        clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        }
            );

        createLobbyButton.onClick.AddListener(() =>
        {
            myLobbyScript.CreateLobby();

        }
            );
    }
}