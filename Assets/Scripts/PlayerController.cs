using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f; // Movement speed
    private float moveDirection;
    private float horizontal;
    private float vertical;
    public GameObject bulletPrefab;
    public Rigidbody player;
    public float TurnTorque=10;
    public Transform bulletSpawnRef;
    public Transform focalPoint;
    public Quaternion defaultRotation;
    private Vector3 defaultPosition;
    public GameObject explosionParticle;

    public float shootForce = 9000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        defaultPosition = transform.position - focalPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
      
        // Get horizontal input (A/D or Arrow keys)
        moveDirection = Input.GetAxis("Horizontal");
        
        // Move the character left/right
        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
        //horizontal = Input.GetAxis("Mouse X");
        //vertical = Input.GetAxis("Mouse Y");

        //if (Input.GetMouseButton(1)) //0 - Left Click , 1 - Right Click 2- middle click
        //{
        //    // transform.Rotate(Vector3.up, horizontal * Time.deltaTime * MovementSpeed);
        //    // transform.Rotate(-1 * Vector3.right, vertical * Time.deltaTime * MovementSpeed);
        //    player.AddRelativeTorque(-1 * vertical * TurnTorque, horizontal * TurnTorque, 0);
        //}
        //if(Input.GetMouseButton(2)) {
        //    transform.rotation = defaultRotation;
        //}


        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnRef.position, bulletSpawnRef.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward *shootForce);
            Destroy(bullet, 5);
        }
        if (transform.position.x > 42)
        {
            transform.position = new Vector3(42, 0, 0);
        }
        else if (transform.position.x < -47) { transform.position = new Vector3(-47, 0, 0); }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            GameManager.Instance.DecreaseHealth(3);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            transform.position = defaultPosition;

        }
    }


}

