using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 25f; // Movement speed
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
    public float tiltAngle = 15f; // Maximum tilt angle
    public float tiltSpeed = 5f;  // How quickly it tilts

    private AudioManager audioManager;
    private bool isMoving = false;
    private float fixedY;
    public float shootForce = 9000f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        defaultPosition = transform.position - focalPoint.position;
        fixedY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input (A/D or Arrow keys)
        moveDirection = Input.GetAxisRaw("Horizontal");

        // Move the character left/right
        transform.position = new Vector3(
          transform.position.x + moveDirection * moveSpeed * Time.deltaTime,
          fixedY,
          transform.position.z
      );
        float targetTilt = moveDirection * -tiltAngle;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetTilt);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);

        //This is the logic for if the player is moving
        //Turns on/off the moving sfx
        if (moveDirection != 0 && !isMoving)
        {
            isMoving = true;
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlayRocketSound();
            }
        }
        else if (moveDirection == 0 && isMoving)
        {
            isMoving = false;
            if (AudioManager.instance != null)
            {
                AudioManager.instance.StopRocketSound();
            }
        }



        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            //Added bullet shot audio here
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.bulletClip);
            }

                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnRef.position, bulletSpawnRef.rotation);

                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnRef.forward * shootForce);
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
            //Added explosion audio here
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.explosionClip);
            }

            GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            GameManager.Instance.DecreaseHealth(3);
            GameManager.Instance.ResetMultiplier();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = defaultPosition;
        }
    }
}

