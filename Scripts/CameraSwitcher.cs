using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // Drag cameras here
    private int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == currentIndex);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameras[currentIndex].enabled = false;
            currentIndex = (currentIndex + 1) % cameras.Length;
            cameras[currentIndex].enabled = true;

            Debug.Log("Switched to: " + cameras[currentIndex].name);
        }
    }
}
