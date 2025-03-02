using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public Transform spawnPoint;
    public Transform focalPoint;
    public float speed = 3000f;
    private float spawnRandomRange = 20f;
    public float spawnInterval = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        float randPositionX = Random.Range(spawnRandomRange, -spawnRandomRange);
        float randEnemy = Random.Range(0, 3);
        if (randEnemy == 0)
        {
            GameObject Enemy = Instantiate(enemyPrefab1, new Vector3(spawnPoint.position.x+ randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
           // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 5000);
        }
        else if (randEnemy == 1)
        {
            GameObject Enemy = Instantiate(enemyPrefab2, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
           // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 5000);
        }
        else if (randEnemy == 2)
        {
            GameObject Enemy = Instantiate(enemyPrefab3, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
           // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 5000);
        }
    }
}
