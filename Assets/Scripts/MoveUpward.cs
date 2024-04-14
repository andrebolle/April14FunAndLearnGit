using UnityEngine;

public class MoveUpward : MonoBehaviour
{
    public float force = 5.0f; // Adjust this value to control the upward force
    private float totalTime = 0;

    private Rigidbody cylinderRigidbody;
    private float lastLogTime = 0.0f; // Stores time of the last log message

    void Start()
    {
        Physics.gravity = Vector3.zero;
        Time.timeScale = 1;
        // Add and Get the Rigidbody component of the cylinder
        cylinderRigidbody = GetComponent<Rigidbody>();
    }

    // Apply upward impulse in FixedUpdate for more consistent physics application
    void FixedUpdate()
    {
        //cylinderRigidbody.AddForce(Vector3.up * force * Time.deltaTime, ForceMode.Force);
        cylinderRigidbody.AddForce(Vector3.up * force, ForceMode.Force);
        totalTime += Time.deltaTime;

        // Print debug log every second based on elapsed time
        if (Time.time - lastLogTime >= 1.0f)
        {
            //Debug.Log($"Time, Height: {(int)totalTime}, {transform.position.y}, Force = {force}, Mass = {cylinderRigidbody.mass}, Acc = {force / cylinderRigidbody.mass}");
            lastLogTime = Time.time;
        }
    }
}