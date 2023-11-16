using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEditor.Rendering;
using Newtonsoft.Json.Bson;
using System.Threading;
using System.Runtime.InteropServices;
using QFSW.QC;

public class TestLobby_2 : NetworkBehaviour
{

    private Lobby hostLobby;
    private Lobby joinedLobby;
    public float lobbyHeartBeatTimer;
    public float lobbyHeartBeatTimerMax;
    public string playerName;


    // Start is called before the first frame update
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in: " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        playerName = "DirtRacer" + UnityEngine.Random.Range(1, 10);
        Debug.Log(playerName);
    }

    public async void CreateLobby()
    {
        try
        {

            string lobbyName = "DirtLobby";
            int maxPlayers = 4;

            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = false,
                Player = GetPlayer()
                
                
              
            };


            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);

            hostLobby = lobby;
            joinedLobby = hostLobby;

            PrintPlayerData(lobby);

            Debug.Log("Lobby has been created: " + lobby.Name + " " + lobby.MaxPlayers + " " + lobby.Id + " " + lobby.LobbyCode);

        } catch (LobbyServiceException e)

        {
            Debug.Log(e);
        }
    }

    public async void ListLobbies()
    {
        QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions
        {
            Count = 5,
            Filters = new List<QueryFilter>
                {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots,"0", QueryFilter.OpOptions.GT)
                },
            Order = new List<QueryOrder>
                {
                new QueryOrder(false,QueryOrder.FieldOptions.Created),
                }
        };

       QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(queryLobbiesOptions);

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

    ////JOINING FIRST LOBBY AVAILABLE
   
    //public async void JoinLobby()
    //{
    //    //QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();

    //    await Lobbies.Instance.JoinLobbyByCodeAsync(queryResponse.Results[0].Id);
    //    Debug.Log("Joined Lobby: " + hostLobby.Name);

    //}

    //JOINING LOBBY BY CODE FUNCTION
    public async void JoinLobbyByCode(string _lobbyCode)
    {
        JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions
        {
            Player = GetPlayer()
        };


        Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(_lobbyCode, joinLobbyByCodeOptions);

        joinedLobby = lobby;

        Debug.Log("Joined Lobby: " + hostLobby.Name + " with code " + _lobbyCode);

        PrintPlayerData(joinedLobby);

    }

    public async void JoinLobby()
    {
        

        //QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions
        //{
        //    Count = 5,
        //    Filters = new List<QueryFilter>
        //        {
        //            new QueryFilter(QueryFilter.FieldOptions.AvailableSlots,"0", QueryFilter.OpOptions.GT)
        //        },
        //    Order = new List<QueryOrder>
        //        {
        //        new QueryOrder(false,QueryOrder.FieldOptions.Created),
        //        }
        //};

        QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();

        Debug.Log("Lobbies Found: " + queryResponse.Results);
        await Lobbies.Instance.JoinLobbyByCodeAsync(queryResponse.Results[0].Id);


        foreach (Lobby lobby in queryResponse.Results)
        {
            Debug.Log(lobby.Name + lobby.MaxPlayers);
        }
    }



    public async void OnApplicationQuit()
    {
        await LobbyService.Instance.QuickJoinLobbyAsync();
        Debug.Log("Quick Joined Lobby: " + hostLobby.Name);
    }

    private void PrintPlayerData()
    {
        PrintPlayerData(joinedLobby);
    }
    public void PrintPlayerData(Lobby lobby)
    {
        Debug.Log("Players in Lobby " + lobby.Name);

        foreach (Player player in lobby.Players)
        {
            Debug.Log("Player ID: " + player.Id + player.Data["PlayerName"].Value);
        }
    }

    public Player GetPlayer()
    {

        return new Player
        {

            Data = new Dictionary<string, PlayerDataObject>
                    {
                        { "PlayerName", new PlayerDataObject (PlayerDataObject.VisibilityOptions.Member, playerName) }

                    }

        };
     }


    void Update()
    {
        HandleHeartBeat();
    }
}
