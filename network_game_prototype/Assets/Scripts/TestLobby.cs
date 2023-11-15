using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEditor.Rendering;
using Newtonsoft.Json.Bson;
using QFSW.QC;

public class TestLobby : MonoBehaviour
{

    private Lobby hostLobby;
    public float lobbyHeartBeatTimer;
    public float lobbyHeartBeatTimerMax;

    // Start is called before the first frame update
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in: " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

    }

    [Command]
    public async void CreateLobby()
    {
        try
        {

            string lobbyName = "DirtLobby";
            int maxPlayers = 4;

            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = false
            };


            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);
            hostLobby = lobby;

            PrintPlayerData(lobby);

            Debug.Log("Lobby has been created: " + lobby.Name + " " + lobby.MaxPlayers + " " + lobby.Id + " " + lobby.LobbyCode);

        } catch (LobbyServiceException e)

        {
            Debug.Log(e);
        }
    }

    public async void ListLobbies()
    {
       QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();
       Debug.Log("Lobbies Found: " + queryResponse.Results);
        foreach (Lobby lobby in queryResponse.Results)
        {
            Debug.Log(lobby.Name + lobby.MaxPlayers);
        }
    }

    public async void HandleHeartBeat()
    {
        if(hostLobby != null)
        {
            lobbyHeartBeatTimer -= Time.deltaTime;
            if(lobbyHeartBeatTimer <0f)
            {
                lobbyHeartBeatTimer = lobbyHeartBeatTimerMax;
                await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
                Debug.Log("Sent Heartbeat to " + hostLobby.Name);
            }
        }
    }

    // JOINING FIRST LOBBY AVAILABLE
    //public async void JoinLobby()
    //{
    //    //QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();

    //    await Lobbies.Instance.JoinLobbyByCodeAsync(queryResponse.Results[0].Id);
    //    Debug.Log("Joined Lobby: " + hostLobby.Name);

    //}

    // JOINING LOBBY BY CODE FUNCTION
    //public async void JoinLobbyByCode(string _lobbyCode)
    //{


    //    await Lobbies.Instance.JoinLobbyByCodeAsync(_lobbyCode);
    //    Debug.Log("Joined Lobby: " + hostLobby.Name + " with code " + _lobbyCode);

    //}
    public async void OnApplicationQuit()
    {
        await LobbyService.Instance.QuickJoinLobbyAsync();
        Debug.Log("Quick Joined Lobby: " + hostLobby.Name);
    }

    public void PrintPlayerData(Lobby lobby)
    {
        Debug.Log("Players in Lobby " + lobby.Name);

        foreach (Player player in lobby.Players)
        {
            Debug.Log("Player ID: " + player.Id);
        }
    }


    void Update()
    {
        HandleHeartBeat();
    }
}
