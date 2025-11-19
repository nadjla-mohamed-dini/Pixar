using UnityEngine;
using UnityEngine.InputSystem;

public class RobotRunner2D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public float speedMultiplier = 1f;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic; 
        rb.gravityScale = 2f; 
    }

    void Update()
    {
        
        rb.linearVelocity = new Vector2(speed * speedMultiplier, rb.linearVelocity.y);

        
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
