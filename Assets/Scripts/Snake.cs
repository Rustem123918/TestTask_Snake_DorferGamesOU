using System.Collections;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float turnSpeed = 8f;
    public float rightBord = 3f;

    [Space]
    [Header("Fever mode properties")]
    public bool feverMode = false;
    public float speedIncreaseValue = 3f;
    public float feverModeTime = 5f;

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
    public IEnumerator EnableFeverMode()
    {
        feverMode = true;
        forwardSpeed *= speedIncreaseValue;
        Move(new Vector3(0 - transform.position.x, 0, 0), true);
        yield return new WaitForSeconds(feverModeTime);
        forwardSpeed /= speedIncreaseValue;
        feverMode = false;
    }
}
