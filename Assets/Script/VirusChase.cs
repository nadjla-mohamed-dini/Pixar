using UnityEngine;

public class VirusChase2D : MonoBehaviour
{
    public Transform robot;       
    public float speed = 3f;      
    public float speedMultiplier = 1f; 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if (robot == null) return;

        
        float directionX = Mathf.Sign(robot.position.x - transform.position.x);

        
        rb.linearVelocity = new Vector2(directionX * speed * speedMultiplier, 0);
    }
}
