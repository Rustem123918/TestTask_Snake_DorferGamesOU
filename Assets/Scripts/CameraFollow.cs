using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance;

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + distance);
    }
}
