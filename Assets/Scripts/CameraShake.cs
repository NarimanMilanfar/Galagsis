using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public static CameraShake Instance;

    private void Awake()
    {
        // Assign the singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    public static void Shake(float duration, float strength)
    {
        if (Instance != null)
        {
            Instance.OnShake(duration, strength);
        }
        else
        {
            Debug.LogWarning("CameraShake.Instance is not assigned!");
        }
    }

    private void OnShake(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }
}
