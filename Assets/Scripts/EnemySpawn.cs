using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] float spawnRate = 2f;
    [SerializeField] GameObject enemy;
    float nextSpawn = 0f;
    Vector2 spawnPos=new Vector2();
    void Start()
    {
        nextSpawn = spawnRate;   
    }

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
    }

    
}
