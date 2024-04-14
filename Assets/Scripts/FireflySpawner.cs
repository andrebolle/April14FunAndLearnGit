using UnityEngine;

public class FireflySpawner : MonoBehaviour
{
    [SerializeField] private GameObject fireflyPrefab; // Prefab for the firefly
    [SerializeField] private int numberOfFireflies = 10; // Number of fireflies to spawn
    [SerializeField] private float spawnRadius = 5f; // Radius around the spawner to spawn fireflies
    [SerializeField] private float movementSpeed = 1f; // Speed of the firefly movement

    void Start()
    {
        // Spawn fireflies
        for (int i = 0; i < numberOfFireflies; i++)
        {
            // Random position within the spawn radius
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            // Create a new firefly object
            GameObject firefly = Instantiate(fireflyPrefab, spawnPosition, Quaternion.identity);

            // Parent the firefly to this object (optional for organization)
            firefly.transform.parent = transform;

            // Add the "Firefly" tag to the firefly object
            //firefly.tag = "Firefly";
        }
    }

    void Update()
    {
        // Move all child firefly objects
        foreach (Transform child in transform)
        {
            // Skip if the child isn't a firefly (improves robustness)
            if (!child.CompareTag("Firefly"))
            {
                continue;
            }

            // Random movement direction
            Vector3 movementDirection = Random.insideUnitSphere;

            // Move the firefly in the random direction
            child.position += movementDirection * movementSpeed * Time.deltaTime;

            // Wrap around the spawn area (optional)
            if (Vector3.Distance(child.position, transform.position) > spawnRadius)
            {
                child.position = transform.position + (child.position - transform.position).normalized * spawnRadius;
            }
        }
    }
}
