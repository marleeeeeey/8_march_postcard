using System;
using UnityEngine;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    public List<GameObject> countPrefabs;
    public GameObject winMessagePrefab;

    private GameObject spawnedObjectsParent;
    
    private void Start()
    {
        winMessagePrefab.SetActive(false);
        
        spawnedObjectsParent = new GameObject("GeneratedObjects");
        spawnedObjectsParent.transform.SetParent(transform);
        spawnedObjectsParent.transform.localPosition = Vector3.zero;
    }

    public void SetScore(int score)
    {
        if (score < 1)
        {
            return;
        }

        foreach (Transform child in spawnedObjectsParent.transform)
        {
            Destroy(child.gameObject);
        }
        
        if (score > countPrefabs.Count)
            score = countPrefabs.Count;
        
        GameObject imageWithNumber = countPrefabs[score - 1];
        Instantiate(imageWithNumber, spawnedObjectsParent.transform);
        
        if (score == countPrefabs.Count)
        {
            winMessagePrefab.gameObject.SetActive(true);
        }
    }
}