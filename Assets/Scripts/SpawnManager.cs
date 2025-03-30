using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
    private float spawnRandomRange = 40f;
    private float spawnInterval = 5f;
    public GameManager gameManager;
    private float randEnemy;
    public GameObject bulletPrefab;
    public Transform bulletSpawnRef;
    public float shootForce = 9000f;
    public float bulletoffset;
    public float bulletoffset2;
    public float bulletoffset3;
    public GameObject explosionParticle;
    public GameObject spawnRingPrefab;


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

    async void SpawnEnemy()
    {
        if (gameManager.isGameOver == true)
        {
            return;
        }
        int randPositionX = (int)Random.Range(spawnRandomRange, -spawnRandomRange);
        int randPositionX2 =(int) Random.Range(spawnRandomRange, -spawnRandomRange);

        float randEnemy = Random.Range(0, 3);
        if (gameManager.GetScore() > 33) { randEnemy += 3; }



        if (randEnemy == 0)
        {
            randPositionX -= 30;

            for (int i = 0; i < 3; i++)
            {
                randPositionX = randPositionX + 15;
                if (randPositionX > spawnRandomRange)
                {

                }
                else { 
                GameObject Enemy = Instantiate(enemyPrefab1, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
                Instantiate(spawnRingPrefab, Enemy.transform.position, Quaternion.Euler(0, 0, 0));
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
                Destroy(Enemy, 5);
            }
            }
            randPositionX -= 30;
            if (randPositionX < -30)
            {

            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    randPositionX = randPositionX - 15;
                    if (randPositionX < -spawnRandomRange)
                    {
                    }
                    else
                    {
                        GameObject Enemy = Instantiate(enemyPrefab1, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
                        Instantiate(spawnRingPrefab, Enemy.transform.position, Quaternion.Euler(0, 0, 0));
                        Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
                        Destroy(Enemy, 5);
                    }
                }
            }
        }
        else if (randEnemy == 1)
        {
            GameObject Enemy = Instantiate(enemyPrefab2, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            Instantiate(spawnRingPrefab, Enemy.transform.position, Quaternion.Euler(0, 0, 0));

            if (Enemy != null){
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);

                if (randPositionX > 0)
                {
                    Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.right * 500);
                    await WaitForSecondsFunction();

                    if (Enemy != null)
                    {
                        Enemy.GetComponent<Rigidbody>().AddForce(-spawnPoint.right * 1200);
                    }
                    await WaitForSecondsFunction();

                    if (Enemy != null)
                    {
                        Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.right * 2000);
                    }
                }
                
                if (randPositionX < 0)
                {
                    Enemy.GetComponent<Rigidbody>().AddForce(-spawnPoint.right * 500);
                    await WaitForSecondsFunction();

                    if (Enemy != null)
                    {
                        Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.right * 1200);
                    }
                    await WaitForSecondsFunction();

                    if (Enemy != null)
                    {
                        Enemy.GetComponent<Rigidbody>().AddForce(-spawnPoint.right * 2000);
                    }
                }
                Destroy(Enemy, 5);
            }

            Destroy(Enemy, 5);
        }

        else if (randEnemy == 2)
        {
            GameObject Enemy = Instantiate(enemyPrefab3, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z), spawnPoint.rotation);
            Instantiate(spawnRingPrefab, Enemy.transform.position, Quaternion.Euler(0, 0, 0));
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
            Destroy(Enemy, 5);
        }
        else if (randEnemy == 3)
        {
            randPositionX -= 30;

            for (int i = 0; i < 3; i++)
            {
                randPositionX = randPositionX + 15;
                if (randPositionX > spawnRandomRange||randPositionX==randPositionX2||randPositionX==randPositionX2+1||randPositionX==randPositionX2-1)
                {

                }
                       
                else
                {
                    GameObject Enemy2 = Instantiate(enemyPrefab1, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z ), spawnPoint.rotation);
                    Instantiate(spawnRingPrefab, Enemy2.transform.position, Quaternion.Euler(0, 0, 0));
                    Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
                    Destroy(Enemy2, 5);
                }
            }
            randPositionX -= 30;
            if (randPositionX < -30)
            {

            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    randPositionX = randPositionX - 15;
                    if (randPositionX < -spawnRandomRange)
                    {
                    }
                    else
                    {
                        GameObject Enemy2 = Instantiate(enemyPrefab1, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z-5f), spawnPoint.rotation);
                        Instantiate(spawnRingPrefab, Enemy2.transform.position, Quaternion.Euler(0, 0, 0));
                        Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
                        Destroy(Enemy2, 5);
                    }
                }
            }

            GameObject Enemy = Instantiate(enemyPrefab4, new Vector3(spawnPoint.position.x + randPositionX2, spawnPoint.position.y, spawnPoint.position.z-15f), spawnPoint.rotation);
            Instantiate(spawnRingPrefab, Enemy.transform.position, Quaternion.Euler(0, 0, 0));
            bulletoffset3 = Random.Range(-45f, 45f);
            GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset3, bulletSpawnRef.position.y, bulletSpawnRef.position.z-3f), bulletSpawnRef.rotation);
            bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
            Destroy(bullet1, 5);
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 7000);
            Destroy(Enemy, 5);

            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 5000);
                bulletoffset = Random.Range(-45f, 45f);
                bulletoffset2 = Random.Range(-45f, 45f);
                GameObject bullet3 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset, bulletSpawnRef.position.y, bulletSpawnRef.position.z-5f), bulletSpawnRef.rotation);
                bullet3.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet3, 5);
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset2, bulletSpawnRef.position.y, bulletSpawnRef.position.z-7f), bulletSpawnRef.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet2, 5);

            }
        }
        else if (randEnemy == 4)
        {
            GameObject Enemy = Instantiate(enemyPrefab5, new Vector3(spawnPoint.position.x + randPositionX2, spawnPoint.position.y, spawnPoint.position.z - 10f), spawnPoint.rotation);
            Instantiate(spawnRingPrefab, Enemy.transform.position, Quaternion.Euler(0, 0, 0));
            GameObject Enemy2 = Instantiate(enemyPrefab2, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z+5f), spawnPoint.rotation);
            Instantiate(spawnRingPrefab, Enemy2.transform.position, Quaternion.Euler(0, 0, 0));

            if (Enemy2 != null)
            {
                Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
            }

            if (Enemy != null)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 7000);
            }

            Destroy(Enemy, 5);

            bulletoffset3 = Random.Range(-45f, 45f);
            GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset3, bulletSpawnRef.position.y, bulletSpawnRef.position.z-3), bulletSpawnRef.rotation);
            if (bullet1.TryGetComponent<Rigidbody>(out Rigidbody bulletRb1))
            {
                bulletRb1.AddForce(bulletSpawnRef.forward * shootForce);
            }
            Destroy(bullet1, 5);

            if (gameManager.GetScore() > 66)
            {
                if (Enemy != null)
                {
                    Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 5000);
                }

                bulletoffset = Random.Range(-45f, 45f);
                bulletoffset2 = Random.Range(-45f, 45f);

                GameObject bullet3 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset, bulletSpawnRef.position.y, bulletSpawnRef.position.z-5), bulletSpawnRef.rotation);
                if (bullet3.TryGetComponent<Rigidbody>(out Rigidbody bulletRb3))
                {
                    bulletRb3.AddForce(bulletSpawnRef.forward * shootForce);
                }
                Destroy(bullet3, 5);

                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset2, bulletSpawnRef.position.y, bulletSpawnRef.position.z-7), bulletSpawnRef.rotation);
                if (bullet2.TryGetComponent<Rigidbody>(out Rigidbody bulletRb2))
                {
                    bulletRb2.AddForce(bulletSpawnRef.forward * shootForce);
                }
                Destroy(bullet2, 5);
            }

            if (randPositionX > 0)
            {
                if (Enemy2 != null)
                {
                    Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.right * 500);
                }

                await WaitForSecondsFunction();

                if (Enemy2 != null)
                {
                    Enemy2.GetComponent<Rigidbody>().AddForce(-spawnPoint.right * 1200);
                }

                await WaitForSecondsFunction();

                if (Enemy2 != null)
                {
                    Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.right * 2000);
                }
            }

            if (randPositionX < 0)
            {
                if (Enemy2 != null )
                {
                    Enemy2.GetComponent<Rigidbody>().AddForce(-spawnPoint.right * 500);
                }

                await WaitForSecondsFunction();

                if (Enemy2 != null)
                {
                    Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.right * 1200);
                }

                await WaitForSecondsFunction();

                if (Enemy2 != null)
                {
                    Enemy2.GetComponent<Rigidbody>().AddForce(-spawnPoint.right * 2000);
                }
            }

            Destroy(Enemy2, 5);
        }

        else if (randEnemy == 5)
        {
            GameObject Enemy = Instantiate(enemyPrefab6, new Vector3(spawnPoint.position.x + randPositionX2, spawnPoint.position.y, spawnPoint.position.z - 10f), spawnPoint.rotation);
            Instantiate(spawnRingPrefab, Enemy.transform.position, Quaternion.Euler(0, 0, 0));
            Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 7000);
            GameObject Enemy2 = Instantiate(enemyPrefab3, new Vector3(spawnPoint.position.x + randPositionX, spawnPoint.position.y, spawnPoint.position.z+5f), spawnPoint.rotation);
            Instantiate(spawnRingPrefab, Enemy2.transform.position, Quaternion.Euler(0, 0, 0));
            Enemy2.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 6000);
            bulletoffset3 = Random.Range(-45f, 45f);
            GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset3, bulletSpawnRef.position.y, bulletSpawnRef.position.z-3f), bulletSpawnRef.rotation);
            bullet1.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
            Destroy(bullet1, 5);
            Destroy(Enemy, 5);
            Destroy(Enemy2, 5);
            if (gameManager.GetScore() > 66)
            {
                Enemy.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 5000);
                bulletoffset = Random.Range(-45f, 45f);
                bulletoffset2 = Random.Range(-45f, 45f);
                GameObject bullet3 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset, bulletSpawnRef.position.y, bulletSpawnRef.position.z-5f), bulletSpawnRef.rotation);
                bullet3.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet3, 5);
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(bulletSpawnRef.position.x + bulletoffset2, bulletSpawnRef.position.y, bulletSpawnRef.position.z-7f), bulletSpawnRef.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
                Destroy(bullet2, 5);
            }
        }
    }
    async Task WaitForSecondsFunction()
    {
        await Task.Delay(1500);
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
