using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int maxEnemy = 5;
    public float distance = 1;
    public float timeSpawn = 5f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeSpawn;
        enemyPrefab.transform.position = new Vector3(23, -4, 4);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            if (transform.childCount < maxEnemy)
            {
                Instantiate(enemyPrefab, Random.insideUnitCircle * distance, Quaternion.identity, transform);

            }
        }
    }
}
