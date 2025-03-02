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
    public float bulletoffset;
    public float bulletoffset2;


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
            spawnInterval = 1f;
            
        }
        else if (gameManager.GetScore() > 33)
        {
            spawnInterval = 2f;
        }
        else
        {
            spawnInterval = 3f;
        }
    }
    void SpawnEnemy()
    {
        float randPositionX = Random.Range(spawnRandomRange, -spawnRandomRange);
        float randEnemy = Random.Range(0, 3);
        if (gameManager.GetScore() > 33) { randEnemy += 3; }
        Debug.Log("rand"+randEnemy);
        Debug.Log("score"+gameManager.GetScore());


        if (randEnemy == 0)
        {
            GameObject Enemy = Instantiate(enemyPrefab1, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
        }
        else if (randEnemy == 1)
        {
            GameObject Enemy = Instantiate(enemyPrefab2, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
        }
        else if (randEnemy == 2)
        {
            GameObject Enemy = Instantiate(enemyPrefab3, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
        }
        else if (randEnemy == 3)
        {
            GameObject Enemy = Instantiate(enemyPrefab4, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 7000);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 9000);
                bulletoffset=Random.Range(-45f, 45f);
                bulletoffset2 = Random.Range(-45f, 45f);
                GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x+bulletoffset, bulletSpawnRef.position.y,bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet1, 5);
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x+bulletoffset2, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet2, 5);
                
            }
        }
        else if (randEnemy == 4)
        {
            GameObject Enemy = Instantiate(enemyPrefab5, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 7000);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 9000);
                bulletoffset = Random.Range(-45f, 45f);
                bulletoffset2 = Random.Range(-45f, 45f);
                GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet1, 5);
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset2, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet2, 5);
            }
        }
        else if (randEnemy == 5)
        {
            GameObject Enemy = Instantiate(enemyPrefab6, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            // Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, focalPoint.position, speed * Time.deltaTime);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 7000);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 9000);
                bulletoffset = Random.Range(-45f, 45f);
                bulletoffset2 = Random.Range(-45f, 45f);
                GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet1, 5);
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset2, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet2, 5);
            }
        }
    }
}
