using UnityEngine;

public class Car1Controller : MonoBehaviour
{
    public float motorForce = 1500f;
    public float turnForce = 50f;
    public float brakeForce = 3000f; // 🔹 New: brake force amount

    public WheelCollider wheelColliderLF;
    public WheelCollider wheelColliderRF;
    public WheelCollider wheelColliderLR;
    public WheelCollider wheelColliderRR;

    public Transform wheelTransformLF;
    public Transform wheelTransformRF;
    public Transform wheelTransformLR;
    public Transform wheelTransformRR;

    private Rigidbody rb;

    private float motorInput;
    private float steerInput;
    private bool isBraking; // 🔹 New: brake flag

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void HandleInput(float motor, float steer, bool brake)
    {
        motorInput = motor;
        steerInput = steer;
        isBraking = brake; // 🔹 Capture brake input
    }

    void FixedUpdate()
    {
        float motor = motorInput * motorForce;
        float steering = steerInput * turnForce;

        // Apply steering to front wheels
        wheelColliderLF.steerAngle = steering;
        wheelColliderRF.steerAngle = steering;

        // Apply motor to rear wheels
        wheelColliderLR.motorTorque = motor;
        wheelColliderRR.motorTorque = motor;

        if (isBraking)
        {
            ApplyBrakes(brakeForce);
        }
        else
        {
            ApplyBrakes(0f);
        }

        // Update wheel visuals
        UpdateWheel(wheelColliderLF, wheelTransformLF);
        UpdateWheel(wheelColliderRF, wheelTransformRF);
        UpdateWheel(wheelColliderLR, wheelTransformLR);
        UpdateWheel(wheelColliderRR, wheelTransformRR);
    }

    void ApplyBrakes(float brake)
    {
        wheelColliderLF.brakeTorque = brake;
        wheelColliderRF.brakeTorque = brake;
        wheelColliderLR.brakeTorque = brake;
        wheelColliderRR.brakeTorque = brake;
    }

    void UpdateWheel(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
}
