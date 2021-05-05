using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public SnakeBody snakeBody;
    public Snake snake;
    private void OnTriggerEnter(Collider other)
    {
        if(snake.feverMode)
        {
            if (other.CompareTag("Bad Thing") || other.CompareTag("Bad Human"))
            {
                StartCoroutine(snakeBody.Eating());
            }
        }
        else
        {
            if (other.CompareTag("Bad Thing") || other.CompareTag("Bad Human") || other.CompareTag("Finish"))
            {
                GameManager.Instance.Restart();
            }
        }

        if (other.CompareTag("Human"))
        {
            StartCoroutine(snakeBody.Eating());
            ScoreManager.Instance.IncreaseHuman();
            GameManager.Instance.PlayPlusOneAnimation();
        }
        else if (other.CompareTag("Crystal"))
        {
            StartCoroutine(snakeBody.Eating());
            ScoreManager.Instance.IncreaseCrystal();
        }
        else if (other.CompareTag("Finish"))
        {
            GameManager.Instance.Restart();
        }
        else if (other.CompareTag("Level Line"))
        {
            LevelManager.Instance.ChangeSnakeColor();
        }
        else if (other.CompareTag("Change Color"))
        {
            LevelManager.Instance.ChangeHumansColor();
        }
    }
}
