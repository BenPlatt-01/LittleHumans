using UnityEngine;

public class Village : MonoBehaviour
{

    public GameObject workerPrefab;

    public Transform spawnPoint;

    public float timeBetweenSpawns;
    float nextSpawnTime;

    public int numberOfWorkersToSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime) 
        { 
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Instantiate(workerPrefab, spawnPoint.position, Quaternion.identity);
            numberOfWorkersToSpawn--;

            if (numberOfWorkersToSpawn <= 0) 
            {
                Destroy(gameObject); 
            }

        }
        
    }
}
