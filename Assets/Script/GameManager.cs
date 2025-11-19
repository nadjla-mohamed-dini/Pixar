using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float objectifDistance = 50f;
    public Transform robot;
    public Transform virus;

    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI messageText;
    public float currentDistance = 0f;

    private bool isGameOver = false;


    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) return;

        currentDistance = robot.position.z;
        distanceText.text = "Distance: " + Mathf.FloorToInt(currentDistance) + " m";

        if (currentDistance >= objectifDistance)
        {
            Victory();
        }
        
        if (virus.position.z >= robot.position.z - 1f)
        {
            GameOver("Attraper par le virus !");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            GameOver("Le robot à toucher l'eau !");
        }
    }

    void GameOver(string reason)
    {
        isGameOver = true;
        Debug.Log("GAME OVER\n " + reason);
        messageText.color = Color.red;
        Invoke("ReloadScene", 3f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void Victory()
    {
        isGameOver = true;
        Debug.Log("VICTOIRE ! \nDistance atteinte: " + Mathf.FloorToInt(currentDistance) + " m");
        messageText.color = Color.green;
        Invoke("LoadVictoryScene", 3f);
        //SceneManager.LoadScene("VictoryScene"); 
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void LoadVictoryScene()
    {
        SceneManager.LoadScene("VictoryScene");
    }
}
