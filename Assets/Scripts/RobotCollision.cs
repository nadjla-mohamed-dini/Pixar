using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RobotCollision : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip looseSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

    }
    public void PLayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayLooseSound()
    {
        audioSource.PlayOneShot(looseSound);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            PlayLooseSound();
            gameManager.GameOver("Le robot à toucher l'eau !");
        }
    }
}
