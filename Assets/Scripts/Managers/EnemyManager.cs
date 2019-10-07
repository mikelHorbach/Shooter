using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public Transform [] spawnPoints;
    public float spawnTime = 3f;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0) return;

        int spawnIndex  = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnIndex].position , spawnPoints[spawnIndex].rotation);
    }
}
