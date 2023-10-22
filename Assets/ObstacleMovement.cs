using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speedIncreaseOverTime = 0.05f;
    public float maxSpeed = 5f;
    private ScoreManager scoreManager;
    private bool scoreAdded = false;

    // For playing sound
    public AudioClip scoreSound;  // Assign your AudioClip in the inspector
    private AudioSource audioSource;  // AudioSource component reference

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        // Initialize AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)  // If AudioSource is missing
        {
            Debug.LogError("No AudioSource found on this GameObject. Adding one.");
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        // Move the obstacle along the negative Z-axis
        transform.Translate(Vector3.back * GameSettings.BaseSpeed * Time.deltaTime);

        // Scoring condition
        if (transform.position.z <= -7 && !scoreAdded)
        {
            scoreManager.IncreaseScore(1);
            scoreAdded = true;
            
            // Play the sound
            if (scoreSound != null)
            {
                audioSource.PlayOneShot(scoreSound);
            }
            else
            {
                Debug.LogError("No scoreSound AudioClip assigned. Please assign it in the inspector.");
            }
        }

        // Destruction condition
        if (transform.position.z <= -12)
        {
            Destroy(gameObject);
        }

        // Speed increase logic
        GameSettings.BaseSpeed += speedIncreaseOverTime * Time.deltaTime;
        GameSettings.BaseSpeed = Mathf.Clamp(GameSettings.BaseSpeed, 2.0f, maxSpeed);
    }
}
