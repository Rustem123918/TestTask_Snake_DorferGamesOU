using UnityEngine;

public class Snake : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float turnSpeed = 8f;
    public float rightBord = 3f;

    private void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    public void Move(Vector3 translation, bool moveFast)
    {
        if (moveFast)
            transform.Translate(translation);
        else
            transform.Translate(translation * Time.deltaTime * turnSpeed);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -rightBord, rightBord),
            transform.position.y,
            transform.position.z);
    }
}
