﻿using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    
    private const string PLAYER_ID_PREFIX = "Poppins ";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void RegisterPlayer(string netID, Player player) {
        string playerID = PLAYER_ID_PREFIX + netID;
        players.Add(playerID, player);
        player.transform.name = playerID;
    }

    public static void UnRegisterPlayer(string playerID) {
        players.Remove(playerID);
    }

    public static Player GetPlayer(string playerID) {
        return players[playerID];
    }

    /*void OnGUI() {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));
        GUILayout.BeginVertical();

        foreach(string playerId in players.Keys) {
            GUILayout.Label(playerId + " - " + players[playerId].transform.name);
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }*/
    
}
