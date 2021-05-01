using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 1f;

    public float damping = 10f;

    private void Update()
    {
        if (!target)
            return;

        var wantedX = target.position.x;
        var currentX = transform.position.x;
        currentX = Mathf.Lerp(currentX, wantedX, damping * Time.deltaTime);


        transform.position = target.position;
        transform.position += Vector3.back * distance;
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
    }
}
