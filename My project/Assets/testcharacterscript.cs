using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class testcharacterscript : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;

    private Vector2 movement;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue value)
    {
            movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
