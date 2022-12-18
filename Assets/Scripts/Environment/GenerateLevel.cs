using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;

    private Transform playerTransform;
    private float spawnZ = 50.0f;
    private float tileLength = 50.0f;
    private float safeZone = 60.0f;
    private int amnOfTilesOnScreen = 4;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

    private void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amnOfTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    private void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - amnOfTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(section[Random.Range(0, section.Length)]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
    
