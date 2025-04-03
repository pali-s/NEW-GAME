using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Mirror;
using UnityEditor.Animations;

public class CharacterScript : NetworkBehaviour
{
    [SerializeField] private Sprite maleSprite;
    [SerializeField] private Sprite femaleSprite;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    private NetworkManagerLobby networkManager;


    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;

    private Vector2 movement;


    private void Awake()
    {
        networkManager = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<NetworkManagerLobby>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isLocalPlayer)  // Only run this for the local player
        {
            int playerIndex = networkManager.playerIndex;
            Debug.Log("Local player's unique Network ID (netId): " + playerIndex);
            if (playerIndex == 1) 
            {
                spriteRenderer.sprite = maleSprite;
                animator.SetBool("isMale", true);
            }
            else
            {
                spriteRenderer.sprite = femaleSprite;
                animator.SetBool("isMale", false);
            }

        }
    }


    // Update is called once per frame
    void Update()
    {

    }


    private void OnMovement(InputValue value)
    {
        if (isLocalPlayer)  // Only run this for the local player
        {

            movement = value.Get<Vector2>();
            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetFloat("x", movement.x);
                animator.SetFloat("y", movement.y);

                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
    }

    [Client]
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

}
