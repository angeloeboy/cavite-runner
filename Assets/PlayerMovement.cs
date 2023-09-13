using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private int laneIndex = 1;  // 0 = left, 1 = middle, 2 = right
    private Vector3[] lanes;

    private void Start()
    {
        lanes = new Vector3[3];
        lanes[0] = new Vector3(-1, 0, 0);  // left
        lanes[1] = new Vector3(0, 0, 0);   // middle
        lanes[2] = new Vector3(1, 0, 0);   // right
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && laneIndex > 0)
        {
            laneIndex--;
            MoveToLane();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && laneIndex < 2)
        {
            laneIndex++;
            MoveToLane();
        }
    }

    private void MoveToLane()
    {
        transform.position = lanes[laneIndex];
    }
}
