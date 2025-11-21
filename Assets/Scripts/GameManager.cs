using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(RobotCollision))]
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float objectifDistance = 50f;
    public Transform robot;
    public Transform virus;

    public TextMeshProUGUI distanceText;
    public float currentDistance = 0f;

    private bool isGameOver = false;

    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    private Rigidbody2D robotRb;
    private Rigidbody2D virusRb;
    public static GameManager Instance { get; private set; }

    private void Awake() // Ajout
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        robotRb = robot.GetComponent<Rigidbody2D>();
        virusRb = virus.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        currentDistance = robot.position.x;
        distanceText.text = "Distance: " + Mathf.FloorToInt(currentDistance) + " m";

        if (currentDistance >= objectifDistance)
        {
            Victory();
        }
        
        if (virus.position.x >= robot.position.x)
        {
            GameOver("Attraper par le virus !");
        }
    }

    public void GameOver(string reason)
    {
        isGameOver = true;
        Debug.Log("GAME OVER\n " + reason);

        StopCharacters();
        gameOverPanel.SetActive(true);
        
    }

    void Victory()
    {
        isGameOver = true;
        Debug.Log("VICTOIRE ! \nDistance atteinte: " + Mathf.FloorToInt(currentDistance) + " m");


        StopCharacters();
        victoryPanel.SetActive(true);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitter le jeu"); // utile pour tester dans l’éditeur
    }

    public void StopCharacters()
    {
        robotRb.linearVelocity = Vector2.zero;
        virusRb.linearVelocity = Vector2.zero;
        robotRb.bodyType = RigidbodyType2D.Kinematic;
        virusRb.bodyType = RigidbodyType2D.Kinematic;
    }
    

}