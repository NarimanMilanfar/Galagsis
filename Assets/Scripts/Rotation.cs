using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationDuration = 1f; // Time to complete rotation
   // public float interval = 300f; // Time before next rotation

    void Start()
    {
        StartCoroutine(RotateEveryFiveSeconds());
    }

    IEnumerator RotateEveryFiveSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f); // Wait before rotating

            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(
                Random.Range(0f, 360f),
                Random.Range(0f, 360f),
                Random.Range(0f, 360f)
            );

            float elapsedTime = 0f;

            while (elapsedTime < rotationDuration)
            {
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / rotationDuration);
                elapsedTime += Time.deltaTime;
                yield return null; // Wait until the next frame
            }

            transform.rotation = targetRotation; // Ensure it reaches final rotation
        }
    }
}

