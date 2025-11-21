using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = -5f; // Vitesse constante (vers la gauche)
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (rb != null)
        {
            // Appliquer une vitesse constante en X et AUCUN mouvement en Y (0)
            rb.linearVelocity = new Vector2(speed, 0f); 
        }
    }
}