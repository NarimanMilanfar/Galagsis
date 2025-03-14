using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject explosionParticle;
     public GameObject healthPickupPrefab;
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
           GameObject explosion= Instantiate(explosionParticle, transform.position, transform.rotation);


            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(explosion, 2);
            GameManager.Instance.AddScore(1);


            // logic for health pickup, eventually put in own method below
            Debug.Log("Enemy hit by bullet");
            GameObject healthPickup = Instantiate(healthPickupPrefab, transform.position, transform.rotation);
            healthPickup.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
        }
    }

    private void TrySpawnHealthPickup(Vector3 spawnPosition)
    {
        // float randomValue = Random.value; 

        // Debug.Log("About to spawn!");

        // if (randomValue <= healthPickupChance) 
        // {
        //     Debug.Log("should be spawning!");
    //     Instantiate(healthPickupPrefab, spawnPosition, transform.rotation);
    // }
    }
}

