using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    //public float speed = 2.0f;  // Starting speed of the obstacle.
    public float speed = GameSettings.BaseSpeed;  // Starting speed of the obstacle.
    public float speedIncreaseOverTime = 0.05f; // Amount by which speed will increase.
    public float maxSpeed = 5f; // Maximum speed the obstacle can reach.
    
    private ScoreManager scoreManager;
    private bool scoreAdded = false;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        // Move the obstacle along the negative Z-axis.
        transform.Translate(Vector3.back * GameSettings.BaseSpeed * Time.deltaTime);

        if (transform.position.z <= -7 && !scoreAdded)
        {
            scoreManager.IncreaseScore(1);
            scoreAdded = true; // Set the flag to true so the score isn't added again for this obstacle.
        }

        if (transform.position.z <= -12)
        {
            Destroy(gameObject);
        }


        // Increase the speed of the obstacle over time but limit it to maxSpeed.
        GameSettings.BaseSpeed += speedIncreaseOverTime * Time.deltaTime;
        GameSettings.BaseSpeed = Mathf.Clamp(GameSettings.BaseSpeed, 2.0f, maxSpeed);
    }
}
