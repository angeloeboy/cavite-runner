using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5.0f;  // Speed at which the obstacle moves.

    private void Update()
    {
        // Move the obstacle along the negative Z-axis.
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
