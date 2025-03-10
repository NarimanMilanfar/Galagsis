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
    private float spawnRandomRange = 45f;
    private float spawnInterval=5f;
    public GameManager gameManager;
    private float randEnemy;
    public GameObject bulletPrefab;
    public Transform bulletSpawnRef;
    public float shootForce = 9000f;
    public float bulletoffset;
    public float bulletoffset2;
    public float bulletoffset3;
    public GameObject explosionParticle;


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
        float randPositionX2 = Random.Range(spawnRandomRange, -spawnRandomRange);
        float randEnemy = Random.Range(0, 3);
        if (gameManager.GetScore() > 33) { randEnemy += 3; }
       


        if (randEnemy == 0)
        {
            GameObject Enemy = Instantiate(enemyPrefab1, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
        }
        else if (randEnemy == 1)
        {
            GameObject Enemy = Instantiate(enemyPrefab2, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
        }
        else if (randEnemy == 2)
        {
            GameObject Enemy = Instantiate(enemyPrefab3, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
        }
        else if (randEnemy == 3)
        {
            GameObject Enemy2 = Instantiate(enemyPrefab1, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);

            Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
            GameObject Enemy = Instantiate(enemyPrefab4, new Vector3(spawnPoint.position.x + randPositionX2, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            bulletoffset3 = Random.Range(-45f, 45f);
            GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset3, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
            bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
            Destroy(bullet1, 5);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 7000);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 9000);
                bulletoffset=Random.Range(-45f, 45f);
                bulletoffset2 = Random.Range(-45f, 45f);
                GameObject bullet3 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x+bulletoffset, bulletSpawnRef.position.y,bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet1, 5);
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x+bulletoffset2, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet2, 5);
                
            }
        }
        else if (randEnemy == 4)
        {
            GameObject Enemy = Instantiate(enemyPrefab5, new Vector3(spawnPoint.position.x + randPositionX2, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            GameObject Enemy2 = Instantiate(enemyPrefab2, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);

            Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 7000);
            bulletoffset3 = Random.Range(-45f, 45f);
            GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset3, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
            bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
            Destroy(bullet1, 5);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 9000);
                bulletoffset = Random.Range(-45f, 45f);
                bulletoffset2 = Random.Range(-45f, 45f);
                GameObject bullet3 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet1, 5);
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset2, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet2, 5);
            }
        }
        else if (randEnemy == 5)
        {
            GameObject Enemy = Instantiate(enemyPrefab6, new Vector3(spawnPoint.position.x + randPositionX2, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
        
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 7000);
            GameObject Enemy2 = Instantiate(enemyPrefab2, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);

            Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
            bulletoffset3 = Random.Range(-45f, 45f);
            GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset3, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
            bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
            Destroy(bullet1, 5);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 9000);
                bulletoffset = Random.Range(-45f, 45f);
                bulletoffset2 = Random.Range(-45f, 45f);
                GameObject bullet3 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet1, 5);
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset2, bulletSpawnRef.position.y, bulletSpawnRef.position.z), bulletSpawnRef.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet2, 5);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);

            Destroy(explosion, 2);
            GameManager.Instance.DecreaseHealth(10);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(explosion, 2);
            GameManager.Instance.AddScore(1);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            Destroy(explosion, 2);
            GameManager.Instance.AddScore(1);
        }
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        if ((other.gameObject.tag == "Player"))
        {
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(explosion, 2);
            GameManager.Instance.DecreaseHealth(10);
        }
    }

}
