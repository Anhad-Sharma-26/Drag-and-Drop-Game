using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameManager gameManager;        
    public GameObject[] shapePrefabs;
    public Color[] availableColors;
    public Transform spawnPoint;
    public float initialDelay = 1f;
    public float spawnInterval = 2f;

    void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        StartCoroutine(SpawnObjectsRoutine());
    }

    IEnumerator SpawnObjectsRoutine()
    {
        yield return new WaitForSecondsRealtime(initialDelay);

        while (true)
        {
            if (gameManager != null && gameManager.IsGameOver())
            {
                yield break; // game over - stop spawning
            }

            SpawnShapeWithColor();
            yield return new WaitForSecondsRealtime(spawnInterval);
        }
    }

    void SpawnShapeWithColor()
{
    int shapeIndex = Random.Range(0, shapePrefabs.Length);
    int colorIndex = Random.Range(0, availableColors.Length);
    Color chosenColor = availableColors[colorIndex];

    GameObject obj = Instantiate(shapePrefabs[shapeIndex], spawnPoint.position, Quaternion.identity);

    Renderer rend = obj.GetComponent<Renderer>();
    if (rend != null)
    {
        rend.material = new Material(rend.material);
        rend.material.color = chosenColor;
    }

    ShapeIdentity identity = obj.GetComponent<ShapeIdentity>();
    if (identity != null)
    {
        identity.assignedColor = chosenColor;
    }

    // --- NEW: Add a random force or velocity ---
    Rigidbody rb = obj.GetComponent<Rigidbody>();
    if (rb != null)
    {
        // Choose a random angle range for X and/or Z
        float horizontalForce = Random.Range(-4f, 4f); 
        float zForce = 0f; 
        rb.velocity = new Vector3(horizontalForce, rb.velocity.y, zForce);
        
    }
}

}
