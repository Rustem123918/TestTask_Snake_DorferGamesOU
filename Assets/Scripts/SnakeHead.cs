using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeHead : MonoBehaviour
{
    public SnakeBody snakeBody;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            StartCoroutine(snakeBody.Eating());
            Destroy(other.gameObject);
            ScoreManager.Instance.IncreaseHuman();
        }
        else if (other.CompareTag("Crystal"))
        {
            StartCoroutine(snakeBody.Eating());
            Destroy(other.gameObject);
            ScoreManager.Instance.IncreaseCrystal();
        }
        else if (other.CompareTag("Bad Thing") || other.CompareTag("Bad Human") || other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Main");
        }
        else if (other.CompareTag("Start"))
        {
            LevelManager.Instance.ChangeColor();
        }
    }
}
