using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RobotCollision))]
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

        
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            GetComponent<RobotCollision>().PLayJumpSound();
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
