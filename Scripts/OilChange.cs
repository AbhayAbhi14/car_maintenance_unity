using UnityEngine;

public class OilChange : MonoBehaviour
{
    private bool playerInRange = false;
    private bool oilDrained = false;
    private bool oilFilled = false;

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.O) && !oilDrained)
        {
            oilDrained = true;
            Debug.Log("Press 'P' to refill.");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!oilDrained)
            {
                Debug.Log("Please drain the oil");
            }
            else if (!oilFilled)
            {
                oilFilled = true;
                Debug.Log("Oil refilled");
            }
            else
            {
                Debug.Log("Oil already refilled.");
            }
        }

        // 🔄 Reset everything (for testing)
        if (Input.GetKeyDown(KeyCode.R))
        {
            oilDrained = false;
            oilFilled = false;
            Debug.Log("Oil change reset.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press 'O' to drain oil.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Exited oil change zone.");
        }
    }
}
