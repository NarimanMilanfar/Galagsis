using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.ResetRowCount();
            GameManager.Instance.SetX2Inactive();
            GameManager.Instance.SetX3Inactive();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
