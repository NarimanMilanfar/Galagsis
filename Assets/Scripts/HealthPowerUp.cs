using System.Collections;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public GameManager player;
    public GameObject healthBox;
    public int healthBonus = 15;
    private int currentHealth;
    public float spawnInterval = 5f; // change after comfirming it works
    public float timeOnScreen = 4f;
    private bool canSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<GameManager>();
        currentHealth = player.GetHealth();
        StartCoroutine(SpawnHealthPowerUp());
        healthBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter detected with: " + other.gameObject.name + ", Tag: " + other.tag);
        if (other.CompareTag("Player"))
        {
            if (currentHealth <= 75)
            {
                Destroy(gameObject);
                player.SetHealth(currentHealth += healthBonus);
            }
            else
            {
                Destroy(gameObject);
                player.SetHealth(100);
            }
        }
    }

    private IEnumerator SpawnHealthPowerUp()
    {
        while (true)
        {
            if (canSpawn)
            {
                Debug.Log("Spawning health power-up...");

                Vector3 playerPosition = player.transform.position;
                float randomX = Random.Range(-40f, 40f);
                healthBox.transform.position = new Vector3(randomX, playerPosition.y - 2f, playerPosition.z);
                healthBox.SetActive(true);

                Vector3 spawnPosition = transform.position;  // Assuming the healthBox is attached to the object this script is on
                Debug.Log("Health Power-up Spawned at: " + spawnPosition);

                canSpawn = false;

                yield return new WaitForSeconds(timeOnScreen);

                healthBox.SetActive(false);

                yield return new WaitForSeconds(spawnInterval);

                canSpawn = true;
            }
        }

    }
}
