using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{

    public Button serverButton;
    public Button hostButton;
    public Button clientButton;
    public Button createLobbyButton;

    public TestLobby_2 myLobbyScript;
    private void Awake()
    {
        serverButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
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