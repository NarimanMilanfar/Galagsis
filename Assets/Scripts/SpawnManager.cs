using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject enemyPrefab5;
    public GameObject enemyPrefab6;
    public Transform spawnPoint;
    public Transform focalPoint;
    public float speed = 3000f;
    private float spawnRandomRange = 20f;
    private float spawnInterval=5f;
    public GameManager gameManager;
    private float randEnemy;
    public GameObject bulletPrefab;
    public Transform bulletSpawnRef;
    public float shootForce = 9000f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetScore() > 66)
        {
            spawnInterval = 2f;
            
        }
        else if (gameManager.GetScore() > 33)
        {
            spawnInterval = 3f;
        }
        else
        {
            spawnInterval = 5f;
        }
    }
    void SpawnEnemy()
    {
        float randPositionX = Random.Range(spawnRandomRange, -spawnRandomRange);
        if (gameManager.GetScore() >= 33) { float randEnemy = Random.Range(3, 6); }
        else if (gameManager.GetScore() < 33) { float randEnemy = Random.Range(0, 3); }

        if (randEnemy == 0)
        {
            GameObject Enemy = Instantiate(enemyPrefab1, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
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
        else if (randEnemy == 3)
        {
            GameObject Enemy = Instantiate(enemyPrefab4, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 5000);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 8000);
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnRef.position, bulletSpawnRef.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet, 5);
            }
        }
        else if (randEnemy == 4)
        {
            GameObject Enemy = Instantiate(enemyPrefab5, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 5000);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 8000);
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnRef.position, bulletSpawnRef.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet, 5);
            }
        }
        else if (randEnemy == 5)
        {
            GameObject Enemy = Instantiate(enemyPrefab6, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 5000);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 8000);
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnRef.position, bulletSpawnRef.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet, 5);
            }
        }
    }
}
