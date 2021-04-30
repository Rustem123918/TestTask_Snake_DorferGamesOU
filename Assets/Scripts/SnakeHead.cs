using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public Snake snake;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bad Thing"))
        {
            snake.transform.position = Vector3.zero;
        }
    }
}
