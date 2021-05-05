using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public SnakeBody snakeBody;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            StartCoroutine(snakeBody.Eating());
            ScoreManager.Instance.IncreaseHuman();
        }
        else if (other.CompareTag("Crystal"))
        {
            StartCoroutine(snakeBody.Eating());
            ScoreManager.Instance.IncreaseCrystal();
        }
        else if (other.CompareTag("Bad Thing") || other.CompareTag("Bad Human") || other.CompareTag("Finish"))
        {
            GameManager.Instance.Restart();
        }
        else if (other.CompareTag("Start"))
        {
            LevelManager.Instance.ChangeColor();
        }
    }
}
