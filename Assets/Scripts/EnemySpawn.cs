using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] float spawnRate = 2f;
    [SerializeField] GameObject enemy;
    float nextSpawn = 0f;
    Player p;
    void Start()
    {
        nextSpawn = spawnRate;
        p = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            Instantiate(enemy, spawnPos(), Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
    }

    Vector2 spawnPos() // X: -14 to 14 from player; Y: -8 to 8 from player
    {
        Vector2 playerPos =p.getPos();
        int ch = Random.Range(1, 5); // 1:left; 2:top; 3:right; 4:bottom;
        switch (ch)
        {
            case 1: return new Vector2(playerPos.x - 14f, Random.Range(playerPos.y - 8f, playerPos.y + 8f)); break;
            case 2: return new Vector2(Random.Range(playerPos.x - 14f, playerPos.y + 14f), playerPos.y + 8); break;
            case 3: return new Vector2(playerPos.x + 14f, Random.Range(playerPos.y - 8f, playerPos.y + 8f)); break;
            case 4: return new Vector2(Random.Range(playerPos.x - 14f, playerPos.x + 14f), playerPos.y - 8); break;
            default: return (Vector2)transform.position; break;
        }
    }

    
}
