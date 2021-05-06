using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float speed = 100f;
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
