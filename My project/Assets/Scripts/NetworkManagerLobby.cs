using UnityEngine;
using Mirror;

public class NetworkManagerLobby : NetworkRoomManager
{

    // This will be called when a new player joins the lobby
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);

        GameObject player2Object = GameObject.FindGameObjectWithTag("Player2");
        Transform player2 = player2Object.transform.Find("Female");
        Debug.Log(numPlayers);

        // Determine which player is joining (based on the connection)
        int playerIndex = numPlayers; // This will be 0 for Player 1, 1 for Player 2, etc.

        // Activate the respective player object based on playerIndex
        if (playerIndex == 0)
        {
            player2.gameObject.SetActive(false);
        }
        else if (playerIndex == 1)
        {
            player2.gameObject.SetActive(true); // Activate Player 2 object
        }
    }

    // This is an optional override if you want to handle player removal/cleanup
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);

        GameObject player2Object = GameObject.FindGameObjectWithTag("Player2");
        Transform player2 = player2Object.transform.Find("Female");

        // Optionally, deactivate the objects again if needed when a player leaves
        if (numPlayers == 1)
        {
            // Deactivate Player 2 when only one player is left
            player2.gameObject.SetActive(false);
        }
        else if (numPlayers == 0)
        {
            // Deactivate Player 1 when no players are left
            player2.gameObject.SetActive(false);
        }
    }
}