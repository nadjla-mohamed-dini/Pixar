using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 5f;  
    public float heightRange = 0.45f;
    public GameObject squarePrefab;        

    private float timer = 0f;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        float randomHeight = Random.Range(-heightRange, heightRange);

        GameObject newSquare = Instantiate(squarePrefab, transform.position + new Vector3(0, randomHeight, 0), Quaternion.identity);

        Destroy(newSquare, 5f);
    }
}