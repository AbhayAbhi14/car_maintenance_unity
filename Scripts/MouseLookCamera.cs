using UnityEngine;

public class MouseLookCamera : MonoBehaviour
{
    public float sensitivity = 5f;
    public float clampAngle = 80f;

    private float rotY = 0f; // rotation around the Y axis
    private float rotX = 0f; // rotation around the X axis

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked; // lock cursor
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * sensitivity;
        rotX += mouseY * sensitivity;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0f);
        transform.rotation = localRotation;

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None; // unlock cursor
    }
}
