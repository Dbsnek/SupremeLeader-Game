using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;
    public Collider2D[] colliders;
    public float radius;

    [SerializeField] float minSpawnRangeX;
    [SerializeField] float maxSpawnRangeX;
    [SerializeField] float minSpawnRangeY;
    [SerializeField] float maxSpawnRangeY;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        gameManager.OnBombSpawn += GameManager_OnBombSpawn;
    }

    private void GameManager_OnBombSpawn()
    {
        SpawnBomb();
    }

    public void SpawnBomb()
    {
        Vector3 spawnPos = Vector3.zero;
        bool canSpawnHere = false;
        int safetyNet = 0;

        while (!canSpawnHere)
        {
            float spawnPosX = Random.Range(minSpawnRangeX, maxSpawnRangeX);
            float spawnPosY = Random.Range(minSpawnRangeY, maxSpawnRangeY);

            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = PreventSpawnOverlap(spawnPos);

            if(canSpawnHere)
            {
                break;
            }

            safetyNet++;

            if(safetyNet > 50)
            {
                break;
                Debug.Log("Too many spawnattempts!");
            }
        }

        GameObject newBomb = Instantiate(bomb, spawnPos, Quaternion.identity) as GameObject;
       
    }

    bool PreventSpawnOverlap(Vector3 spawnPos)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperextent = centerPoint.y + height;

            if(spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if(spawnPos.y >= lowerExtent && spawnPos.y >= upperextent)
                {
                    return false;
                }
            }
        }
        return true;
    }

}
