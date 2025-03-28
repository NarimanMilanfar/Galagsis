using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 20f, 0f); // degrees per second

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
