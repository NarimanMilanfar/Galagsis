using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Movement speed
    private float moveDirection;
    public float tiltAmount = 5f;
    public Collider playerCollider;
    // public Transform focalPoint;
    private bool isColliding = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            moveDirection = 0f;
        }
        else
        {
            // Get horizontal input (A/D or Arrow keys)
            moveDirection = Input.GetAxis("Horizontal");
        }
        // Move the character left/right
        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
    
       
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isColliding = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            isColliding = false; // Resume movement by setting isColliding to false
        }
    }
 
}

