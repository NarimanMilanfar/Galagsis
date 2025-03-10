using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject explosionParticle;
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
            //Added explosion audio here
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.explosionClip);
            }

            GameObject explosion= Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(explosion, 2);
            GameManager.Instance.AddScore(1);
        }
    }
}

