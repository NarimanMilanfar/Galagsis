using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject explosionParticle;
    public GameObject healthPickupPrefab;
    public float healthPickupChance = 0.1f;
    private float lastSpawnTime = 0f;
    private float spawnCooldown = 7f;
    [SerializeField] private float destroyDelay = 1.9f;

    private AudioManager audioManager;
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
            //Added explosion audio here, loud as it will be destroyed
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.explosionClip);
            }

            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);


            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(explosion, 2);
            GameManager.Instance.AddScore(1);
            GameManager.Instance.AddRowCount();

            if (GameManager.Instance.rowCount > 2)
            {
                GameManager.Instance.AddScore(1);
                GameManager.Instance.SetX2Active();
            }

            if (GameManager.Instance.rowCount > 5)
            {
                GameManager.Instance.AddScore(2);
                GameManager.Instance.SetX2Inactive();
                GameManager.Instance.SetX3Active();
            }


            TrySpawnHealthPickup(transform.position);
        }
    }

    private void TrySpawnHealthPickup(Vector3 spawnPosition)
    {
        if ((Time.time - lastSpawnTime) < spawnCooldown)
        {
            return; 
        }

        float randomValue = Random.value;

        if (randomValue <= healthPickupChance)
        {
            GameObject healthPickup = Instantiate(healthPickupPrefab, transform.position, transform.rotation);
            healthPickup.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            Destroy(healthPickup, destroyDelay);
        }
    }
}

