using UnityEngine;

public class FloorCeilingMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveForce = 1.0f;

    

    void FixedUpdate()
    {
        //rb.AddForce(Vector2.left * moveForce, ForceMode2D.Impulse);
        rb.linearVelocity = new  Vector2(-moveForce, 0);
    }
}
