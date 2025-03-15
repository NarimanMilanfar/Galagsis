using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    public int healthAmount = 10;
    public GameObject explosionParticle;
    public float spinSpeed = 100f;
    public float destroyDelay = 2f;
    public GameObject plusTenSprite;


    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Debug.Log("Health pickup hit by: " + other.gameObject.name);
            GameManager.Instance.HealthBoost(healthAmount);
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            GameObject plusTen = Instantiate(plusTenSprite, transform.position, Quaternion.identity); // change so it doesn't follow rotation of heart
            plusTen.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            Destroy(plusTen, destroyDelay);

        }

    }
}
