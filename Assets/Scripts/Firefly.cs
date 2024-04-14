using UnityEngine;

public class Firefly : MonoBehaviour
{
    [SerializeField] private float lightIntensity = 1f; // Intensity of the light
    [SerializeField] private float minFlashTime = 0.1f; // Minimum time between flashes (seconds)
    [SerializeField] private float maxFlashTime = 0.3f; // Maximum time between flashes (seconds)
    [SerializeField] private Color lightColor = Color.yellow; // Color of the light

    private Light fireflyLight;
    private float nextFlashTime;

    void Start()
    {
        // Get the Light component from this GameObject
        fireflyLight = GetComponent<Light>();

        // Set initial light properties (off by default)
        fireflyLight.intensity = lightIntensity;
        fireflyLight.color = lightColor;
        fireflyLight.enabled = false;

        // Set a random time for the next flash
        nextFlashTime = Random.Range(minFlashTime, maxFlashTime);
    }

    void Update()
    {
        // Check if it's time to flash
        if (Time.time > nextFlashTime)
        {
            // Toggle the light on/off
            fireflyLight.enabled = !fireflyLight.enabled;

            // Set a new random time for the next flash
            nextFlashTime = Time.time + Random.Range(minFlashTime, maxFlashTime);
        }
    }
}
