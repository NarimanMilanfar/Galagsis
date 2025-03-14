using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healthAmount = 10;
    public GameObject explosionParticle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet")) 
        {
            Debug.Log("Health pickup hit by: " + other.gameObject.name);
            GameManager.Instance.HealthBoost(healthAmount); 
            Destroy(other.gameObject); 
            Destroy(gameObject); 
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
        }

    }
}
