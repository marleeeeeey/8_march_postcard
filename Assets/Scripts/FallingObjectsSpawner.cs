using UnityEngine;
using System.Collections;

public class FallingObjectsSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Префабы с разными спрайтами
    public float spawnInterval = 0.5f; // Интервал спавна объектов
    public float fallSpeed = 2f; // Скорость падения объектов
    public float rotationSpeed = 30f; // Скорость вращения объектов
    public Vector2 spawnRange = new Vector2(-8f, 8f); // Диапазон спавна по X
    public Transform parentNode; // Родительский объект для спавна
    public float destroyHeight = -6f; // Высота, на которой уничтожаются объекты

    void Start()
    {
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
        GameObject obj = Instantiate(prefab, spawnPosition, Quaternion.identity, parentNode);
        
        Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(0, -fallSpeed);
        
        obj.AddComponent<FallingObject>();
    }
}

public class FallingObject : MonoBehaviour
{
    private float rotationSpeed;
    private float destroyHeight = -6f; // Высота уничтожения

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