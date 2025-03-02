using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationDuration = 1000000000f; // Time to complete rotation
    public float interval = 30f; // Time before next rotation

    void Start()
    {
        StartCoroutine(RotateEveryFiveSeconds());
    }

    IEnumerator RotateEveryFiveSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval); // Wait before rotating

            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f)
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
