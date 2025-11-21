using UnityEngine;
using UnityEngine.U2D.IK;

public class DataCollect : MonoBehaviour
{
    public static int totalData = 0;
    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player"))
        {
            totalData++;
            Debug.Log("tu as" + DataCollect.totalData +"Data");

            Destroy(gameObject);
        }
    }
}
