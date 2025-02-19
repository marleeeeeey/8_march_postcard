using UnityEngine;
using System.Collections;

public class FallingObjectsSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnInterval = 0.5f;
    public float fallSpeed = 2f;
    public Vector2 spawnRange = new Vector2(-8f, 8f);
    private GameObject spawnedObjectsParent;

    void Start()
    {
        spawnedObjectsParent = new GameObject("GeneratedObjects");
        spawnedObjectsParent.transform.SetParent(transform);
        spawnedObjectsParent.transform.localPosition = Vector3.zero;
        
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        if (objectPrefabs.Length == 0) return;

        GameObject prefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(spawnRange.x, spawnRange.y), Camera.main.orthographicSize + 1f, 0);
        GameObject obj = Instantiate(prefab, spawnPosition, Quaternion.identity, spawnedObjectsParent.transform);

        Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(0, -fallSpeed);

        obj.AddComponent<FallingObject>();
    }
}

public class FallingObject : MonoBehaviour
{
    private float rotationSpeed;
    private float destroyHeight = -6f;

    void Start()
    {
        rotationSpeed = Random.Range(-50f, 50f);
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (transform.position.y < destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}