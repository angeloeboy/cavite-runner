using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private int laneIndex = 1;  // 0 = left, 1 = middle, 2 = right
    private Vector3[] lanes;

    private float transitionSpeed = 7f; // Adjust this value as needed for faster/slower transitions
    private Vector3 targetPosition;


    public Transform lane1, lane2, lane3;



    public float jumpForce = 7f; // The force of the jump, adjustable in the inspector
    private bool isJumping = false; // Flag to check if the player is already jumping
    private Rigidbody playerRigidbody; // Reference to the player's rigidbody

    private void Start()
    {
        lanes = new Vector3[3];
        //lanes[0] = new Vector3(-1, 0, 0);  // left
        //lanes[1] = new Vector3(0, 0, 0);   // middle
        //lanes[2] = new Vector3(1, 0, 0);   // right

        lanes[0] = new Vector3(lane1.position.x, 0.5f, -7);  // corresponds to Lane1
        lanes[1] = new Vector3(lane2.position.x, 0.5f, -7);  // corresponds to Lane2
        lanes[2] = new Vector3(lane3.position.x, 0.5f, -7);  // corresponds to Lane3



        targetPosition = lanes[laneIndex];
        transform.position = targetPosition;


        playerRigidbody = GetComponent<Rigidbody>();
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
        transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Debug.Log("Jump initiated");  // Log to confirm it's not called repeatedly
            isJumping = true;
            Jump();
        }
    }

    private void MoveToLane()
    {
        targetPosition = lanes[laneIndex];
    }

    void Jump()
    {
        Debug.Log("Applying jump force");  // Confirm this only happens once per jump
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ground (consider using tags or layers for more precision)
        if (collision.gameObject.CompareTag("Ground")) // Assumes your ground GameObject has the tag "Ground"
        {
            isJumping = false;
        }
    }


}
