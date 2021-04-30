using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeHead : MonoBehaviour
{
    private Snake _snake;
    private void Start()
    {
        _snake = GetComponentInParent<Snake>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human") || other.CompareTag("Crystal"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bad Thing") || other.CompareTag("Bad Human"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
