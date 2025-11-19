using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public InputAction jump;

    public float jumpForce = 3.0f;
    public float moveSpeed = 5.0f;
 
    void Start()
    {
        jump = InputSystem.actions.FindAction(("Jump"));
    }

    private void FixedUpdate()
    {

        if (jump.IsPressed())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
    }
}
