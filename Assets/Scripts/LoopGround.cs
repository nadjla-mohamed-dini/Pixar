using UnityEngine;

public class LoopGround : MonoBehaviour
{
    public float speed = 1f; 
    public float width = 5f;

    private SpriteRenderer sr;
    private Vector2 startSize;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startSize = new Vector2(sr.size.x, sr.size.y);
    }

    void Update()
    {
        sr.size += Vector2.right * speed * Time.deltaTime;

        if (sr.size.x >= width)
        {
            sr.size = startSize;
        }
    }
}