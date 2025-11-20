using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RobotCollision))]
public class RobotRunner2D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public float speedMultiplier = 1f;

    public float speedIncrement = 0.2f; //vitesse win by collect data
    public int MaxData = 5;
    public float FreezeDuration = 2f;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool isFrozen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic; 
        rb.gravityScale = 2f; 
    }

    void Update()
    {
        if(isFrozen) return; 
        //calculate the speed en fonction des data
        int dataCount = DataCollect.totalData;

        if (dataCount <= MaxData)
        {
            speedMultiplier = 1f + (dataCount * speedIncrement);
        }
        else
        {
            StartCoroutine(FreezeRobot());
        }
        
        rb.linearVelocity = new Vector2(speed * speedMultiplier, rb.linearVelocity.y);

        
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
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
    IEnumerator FreezeRobot()
    {
        isFrozen = true;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(FreezeDuration);
        isFrozen = false;

        DataCollect.totalData = 0;
        speedMultiplier = 1f;
    }
}
