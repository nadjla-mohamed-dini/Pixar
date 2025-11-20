using UnityEngine;

public class CoolingCollect : MonoBehaviour
{
    public int coolingValue = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player"))
        {
            DataCollect.totalData = Mathf.Max(0, DataCollect.totalData - coolingValue);
            Debug.Log("Cooling breack");
            Destroy(gameObject);
        }
    }
}
