using UnityEngine;

public class GarageDoorController : MonoBehaviour
{
    public float openHeight = 5f;
    public float speed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;         // Tracks whether the door is currently open
    private bool isMoving = false;       // Tracks if the door is currently moving

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * openHeight;
        Debug.Log("GarageDoorController attached and started!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isMoving)
        {
            isOpen = !isOpen; // Toggle the door state
            isMoving = true;
            Debug.Log("E key pressed! Toggling door.");
        }

        if (isMoving)
        {
            Vector3 targetPosition = isOpen ? openPosition : closedPosition;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition; // Snap to exact position
                isMoving = false;
                Debug.Log("Door movement finished.");
            }
        }
    }
}
