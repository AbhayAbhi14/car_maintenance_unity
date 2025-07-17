using UnityEngine;

public class CoolantRefill : MonoBehaviour
{
    private bool playerInRange = false;
    private bool isFull = false;
    private float coolantLevel = 0f; // starts empty
    private float maxCoolant = 100f;

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isFull)
            {
                coolantLevel = maxCoolant;
                isFull = true;
                Debug.Log("Coolant refilled to 100%");
            }
            else
            {
                coolantLevel = 0f;
                isFull = false;
                Debug.Log("Coolant drained to 0%");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("?? Press 'R' to refill or drain coolant.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
