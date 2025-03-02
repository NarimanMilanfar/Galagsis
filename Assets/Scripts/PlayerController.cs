using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Movement speed
    private float moveDirection;
    public float tiltAmount = 5f;
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
        if (moveDirection > 0) // Moving right
        {
            transform.rotation = Quaternion.Euler(0, 0, -tiltAmount); // Tilt slightly right
        }
        else if (moveDirection < 0) // Moving left
        {
            transform.rotation = Quaternion.Euler(0, 0, tiltAmount); // Tilt slightly left
        }
       // else // No movement (reset tilt)
       // {
           // transform.rotation = Quaternion.Euler(0, 0, 0); // Reset to no tilt
      //  }
    }
}
