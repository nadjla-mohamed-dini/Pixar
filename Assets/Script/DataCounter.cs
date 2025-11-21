using UnityEngine;
using TMPro;

public class DataCounter : MonoBehaviour
{
    private TextMeshProUGUI counterText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if(counterText.text != null)
        {
            counterText.text = DataCollect.totalData.ToString()+"/5";
        }
    }
}
