using System.Collections;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float rightBord = 1f;
    public float turnTime = 0.5f;

    private bool inTurningProcess = false;
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    public void Move(Vector3 translation)
    {
        StartCoroutine(MoveSmoothly(translation));
    }
    private IEnumerator MoveSmoothly(Vector3 translation)
    {
        if (inTurningProcess)
            yield break;
        inTurningProcess = true;
        var timer = 0f;
        while(timer<turnTime)
        {
            transform.Translate(translation*Time.deltaTime/turnTime);
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -rightBord, rightBord),
                transform.position.y,
                transform.position.z);
            timer += Time.deltaTime;
            yield return null;
        }
        inTurningProcess = false;
    }
}
