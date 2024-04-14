using UnityEngine;

public class ElectronSimulation : MonoBehaviour
{
    public int numberOfElectrons = 10; // Change this value to set the number of electrons
    public GameObject electronPrefab; // Assign the electron prefab in the Unity Editor
    public float maxInitialVelocity = 5f; // Maximum initial velocity magnitude
    public float forceFactor = 5f;
    public float linearDrag = 5f;
    public float sleepThreshold = 5f;
    public PhysicMaterial electronMaterial;

    private GameObject[] electrons;

    void Start()
    {
        // Initialize array to hold electrons
        electrons = new GameObject[numberOfElectrons];

        // Create and position electrons with random initial velocities
        for (int i = 0; i < numberOfElectrons; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)); // Random spawn position within a cube
            electrons[i] = Instantiate(electronPrefab, spawnPosition, Quaternion.identity);

            // Assign random initial velocity
            Rigidbody rb = electrons[i].GetComponent<Rigidbody>();
            Vector3 initialVelocity = new Vector3(Random.Range(-maxInitialVelocity, maxInitialVelocity), Random.Range(-maxInitialVelocity, maxInitialVelocity), Random.Range(-maxInitialVelocity, maxInitialVelocity));
            rb.velocity = initialVelocity;
            rb.drag = linearDrag;
            rb.sleepThreshold = sleepThreshold;

            // Apply the physics material for bounciness
            Collider collider = electrons[i].GetComponent<Collider>();
            collider.material = electronMaterial;

            // Assign unique color to each electron
            Color randomColor = new Color(Random.value, Random.value, Random.value); // Generates a random color
            MeshRenderer renderer = electrons[i].GetComponentInChildren<MeshRenderer>(); // Assuming the MeshRenderer is a child of the electron prefab
            renderer.material.color = randomColor;
        }
    }

    void Update()
    {
        // Apply forces to each pair of electrons
        for (int i = 0; i < numberOfElectrons - 1; i++)
        {
            for (int j = i + 1; j < numberOfElectrons; j++)
            {
                Rigidbody rb1 = electrons[i].GetComponent<Rigidbody>();
                Rigidbody rb2 = electrons[j].GetComponent<Rigidbody>();

                // Calculate force direction
                Vector3 forceDirection = electrons[j].transform.position - electrons[i].transform.position;

                // Apply Coulomb's law to calculate force magnitude
                float distanceSquared = forceDirection.sqrMagnitude;
                float forceMagnitude = forceFactor / distanceSquared; // Assuming unit charges

                // Apply force to each electron
                rb1.AddForce(forceMagnitude * forceDirection);
                rb2.AddForce(-forceMagnitude * forceDirection); // Opposite force for second electron
            }
        }
    }

}
