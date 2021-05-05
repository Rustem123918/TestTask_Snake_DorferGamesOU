using UnityEngine;

public class LevelObject : MonoBehaviour
{
    public float speed = 100f;
    public float destroyTime = 1f;

    private Transform _headSnake;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject, destroyTime);
            Destroy(GetComponent<Collider>());
            GetComponent<Animation>().Play();
            MoveToTheMouth();
        }
    }
    private void MoveToTheMouth()
    {
        _headSnake = GameManager.Instance.snake.transform;
        transform.LookAt(_headSnake);
        transform.Translate((Vector3.forward) * Time.deltaTime * speed);
    }
}
