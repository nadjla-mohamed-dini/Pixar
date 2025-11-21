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
    public GameManager gm;

    public InputAction jump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic; 
        rb.gravityScale = 2f; 
        
        //remove this comment to turn the game into jetpack joyride mode
        //jump = InputSystem.actions.FindAction(("Jump"));
    }

    void Update()
    {
        if (gm.getGameOver() == false)
        {
            rb.linearVelocity = new Vector2(speed * speedMultiplier, rb.linearVelocity.y);


            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
                GetComponent<RobotCollision>().PLayJumpSound();
            }

            //remove this comment to turn the game into jetpack joyride mode
            /*
             *if (jump.IsPressed())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            }
             *
             *
             */
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
