using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScript : MonoBehaviour
{
    public Button hostButton;
    public Button clientButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensure buttons are assigned
        if (hostButton != null)
            hostButton.onClick.AddListener(StartHost);

        if (clientButton != null)
            clientButton.onClick.AddListener(StartClient);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartHost()
    {
        NetworkManager.singleton.StartHost();
        Debug.Log("Host Started");
    }

    void StartClient()
    {
        NetworkManager.singleton.StartClient();
        Debug.Log("Client Started");
    }
}
