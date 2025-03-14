using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healthAmount = 10;
    public GameObject explosionParticle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // If hit by a bullet
        {
            Debug.Log("Health pickup hit by: " + other.gameObject.name);
            GameManager.Instance.HealthBoost(healthAmount); // Increase player's health
            Destroy(other.gameObject); // Destroy the bullet
            Destroy(gameObject); // Destroy the health pickup
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
        }

    }
}
