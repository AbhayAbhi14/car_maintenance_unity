using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    [Tooltip("Target point where the object will go when dropped")]
    public Transform releasePoint; // assign in inspector

    private bool playerInRange = false;
    private Transform grabPoint;
    private bool isGrabbed = false;
    private Transform originalParent;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
    }

    void Update()
    {
        if (!playerInRange || grabPoint == null) return;

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!isGrabbed)
            {
                // Grab
                transform.SetParent(grabPoint);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;

                if (rb != null) rb.isKinematic = true;

                isGrabbed = true;
                Debug.Log($"Grabbed {gameObject.name}");
            }
            else
            {
                // Drop to release point
                transform.SetParent(null);

                if (releasePoint != null)
                {
                    transform.position = releasePoint.position;
                    transform.rotation = releasePoint.rotation;
                }
                else
                {
                    Debug.LogWarning("No release Point");
                }

                if (rb != null) rb.isKinematic = false;

                isGrabbed = false;
                Debug.Log($"Dropped {gameObject.name} ");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            grabPoint = other.transform.Find("GrabPoint");
            if (grabPoint != null)
            {
                playerInRange = true;
                Debug.Log("Press 'H' to grab/drop.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            grabPoint = null;
        }
    }
}
