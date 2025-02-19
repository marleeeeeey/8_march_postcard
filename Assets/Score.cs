using UnityEngine;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    public List<GameObject> countPrefabs;
    public WinMessage winMessage;

    public void SetScore(int score)
    {
        if (score < 1)
        {
            return;
        }

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        if (score > countPrefabs.Count)
            score = countPrefabs.Count;
        
        GameObject prefab = countPrefabs[score - 1];
        Instantiate(prefab, transform);
        
        if (score == countPrefabs.Count)
        {
            winMessage.gameObject.SetActive(true);
        }
    }
}