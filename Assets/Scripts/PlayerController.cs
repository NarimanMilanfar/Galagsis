using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Movement speed
    private float moveDirection;
    public GameObject bulletPrefab;
    
    public Transform bulletSpawnRef;
    public float shootForce = 90000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        // Get horizontal input (A/D or Arrow keys)
        moveDirection = Input.GetAxis("Horizontal");
        
        // Move the character left/right
        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
    
       if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnRef.position, bulletSpawnRef.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward *shootForce);
            Destroy(bullet, 5);
        }

    }

 
}

