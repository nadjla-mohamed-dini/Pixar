using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public RigidBody2D rb;

    public int speed = 5;

    public void FixedUpdate() {
    
        rb.AddForce(speed,0);
 
    }

}
