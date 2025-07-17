using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;
    public GameObject car1;
    public GameObject car2;

    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    private GameObject activeTarget;
    private Animator boyAnimator;
    private Animator girlAnimator;
    private Car1Controller car1Controller;
    private Car1Controller car2Controller;

    void Start()
    {
        activeTarget = boy;

        boyAnimator = boy.GetComponent<Animator>();
        girlAnimator = girl.GetComponent<Animator>();

        car1Controller = car1.GetComponent<Car1Controller>();
        car2Controller = car2.GetComponent<Car1Controller>();
    }

    void Update()
    {
        // Switching characters
        if (Input.GetKeyDown(KeyCode.B))
            activeTarget = boy;

        if (Input.GetKeyDown(KeyCode.G))
            activeTarget = girl;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            activeTarget = car1;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            activeTarget = car2;
    }

    void FixedUpdate()
    {
        if (activeTarget == null) return;

        float motorInput = Input.GetAxis("Vertical");
        float steerInput = Input.GetAxis("Horizontal");
        bool brake = Input.GetKey(KeyCode.Space);

        // Character movement
        if (activeTarget == boy || activeTarget == girl)
        {
            float move = motorInput * moveSpeed * Time.fixedDeltaTime;
            float turn = steerInput * turnSpeed * Time.fixedDeltaTime;

            activeTarget.transform.Translate(Vector3.forward * move);
            activeTarget.transform.Rotate(Vector3.up * turn);

            // Handle animation
            float speed = Mathf.Abs(motorInput);  // 0 when idle, 1 when moving
            Animator animator = activeTarget.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetFloat("Speed", speed);
            }
        }

        // Car movement
        if (activeTarget == car1)
        {
            car1Controller.HandleInput(motorInput, steerInput, brake);
        }
        else if (activeTarget == car2)
        {
            car2Controller.HandleInput(motorInput, steerInput, brake);
        }
    }
}
