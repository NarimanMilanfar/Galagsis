using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    public float amplitude = 0.5f; // height of floating
    public float frequency = 1f;   // speed of floating

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x, startPos.y + yOffset, startPos.z);
    }
}
