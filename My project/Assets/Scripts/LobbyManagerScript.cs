using Mirror;
using System;
using UnityEngine;

public class LobbyManagerScript : MonoBehaviour
{

    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;


    public void SetPlayerObjects(GameObject p1, GameObject p2)
    {
        Player1 = p1;
        Player2 = p2;
    }

}
