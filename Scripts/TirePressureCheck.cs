using UnityEngine;

public class TirePressureCheck : MonoBehaviour
{
    private bool playerInRange = false;
    private float pressure = 30f; // PSI
    private float minPressure = 20f;
    private float maxPressure = 35f;

    void Update()
    {
        if (!playerInRange) return;

        // Check current pressure
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log($" Pressure: {pressure} PSI");
        }

        // Inflate
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (pressure < maxPressure)
            {
                pressure += 1f;
                Debug.Log($"{pressure} PSI");
            }
            else
            {
                Debug.Log($" max pressure ({pressure} PSI)");
            }
        }

        // Deflate
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (pressure > minPressure)
            {
                pressure -= 1f;
                Debug.Log($"{pressure} PSI");
            }
            else
            {
                Debug.Log($"({pressure} PSI)");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log($"Press 'T' to check 'I' to inflate 'F' to deflate.");
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
