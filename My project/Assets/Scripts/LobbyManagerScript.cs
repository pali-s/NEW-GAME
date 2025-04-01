using Mirror;
using System;
using UnityEngine;

public class LobbyManagerScript : NetworkRoomManager
{
    private bool firstPerson;

    // Override the OnServerAddPlayer method to handle player positioning
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // Call the base method to spawn the player object
        base.OnServerAddPlayer(conn);

        // Get the player object using conn.identity (the NetworkIdentity of the player object)
        GameObject player = conn.identity.gameObject;

        Debug.Log(player);

        // Position the player at the correct spawn point
        PositionPlayerInLobby(player);
    }

    // Function to position player in the lobby
    private void PositionPlayerInLobby(GameObject player)
    {
        // Determine which spawn point the player should be positioned at
        int spawnIndex = player.GetComponent<NetworkRoomPlayer>().index;

        Debug.Log(spawnIndex);
        Debug.Log(firstPerson);
        // Set the player's position based on their index
        if (firstPerson == false)
        {
            // Position for player 0 (x = 6, y = 0, z = 0)
            player.transform.position = new Vector3(-2f, 1f, 0f);
            Debug.Log("Positioning Player " + spawnIndex + " at: " + player.transform.position);
            firstPerson = true;
        }
        else if (firstPerson == true)
        {
            // Position for player 1 (x = -6, y = 0, z = 0)
            player.transform.position = new Vector3(-2f, 1f, 0f);
            Debug.Log("Positioning Player " + spawnIndex + " at: " + player.transform.position);
        }
        else
        {
            // Default position if index is out of range (for example, you could add more players here)
            player.transform.position = new Vector3(0f, 0f, 0f); // Or choose any default position
            Debug.LogWarning("No specific position for index " + spawnIndex + ". Assigning default position.");
        }
    }
}
