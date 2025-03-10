using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject explosionParticle;
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
        if (collision.gameObject.tag == "Player")
        {
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            
            Destroy(explosion, 2);
            GameManager.Instance.DecreaseHealth(10);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(explosion, 2);
            GameManager.Instance.AddScore(1);
        }
        if(collision.gameObject.tag== "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}