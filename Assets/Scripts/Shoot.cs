using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject explosionParticle;
    public GameObject healthPickupPrefab;
    public float healthPickupChance = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);


            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(explosion, 2);
            GameManager.Instance.AddScore(1);

            TrySpawnHealthPickup(transform.position);
        }
    }

    private void TrySpawnHealthPickup(Vector3 spawnPosition)
    {
        float randomValue = Random.value;

        if (randomValue <= healthPickupChance)
        {
            GameObject healthPickup = Instantiate(healthPickupPrefab, transform.position, transform.rotation);
            healthPickup.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            Destroy(healthPickup, 1f);
        }
    }
}

